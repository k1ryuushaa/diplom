using ArtRoyalDetailing.Database.Interfaces;
using ArtRoyalDetailing.Domain.Models;
using ArtRoyalDetailing.Domain.Response;
using ArtRoyalDetailing.Domain.ViewModels;
using ArtRoyalDetatiling.Services.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ArtRoyalDetailing.Domain.Enum;
using ArtRoyalDetailing.Domain.Helpers;
using System.Linq;

namespace ArtRoyalDetatiling.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly ILogger<UserService> _logger;
        private readonly IBaseRepository<Users> _userRepository;
        private readonly IBaseRepository<Roles> _rolesRepository;
        public UserService(ILogger<UserService> logger, IBaseRepository<Users> userRepository, IBaseRepository<Roles> rolesRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
            _rolesRepository = rolesRepository;
        }
        public async Task<BaseResponse<Users>> Create(UserViewModel model)
        {
            try
            {
                var user = await _userRepository.GetAll().FirstOrDefaultAsync(x=>x.UserLogin==model.Login);
                if (user != null)
                {
                    return new BaseResponse<Users>()
                    {
                        Description = "Пользователь с таким логином уже есть",
                        StatusCode = StatusCode.AlreadyExists
                    };
                }
                user = new Users()
                {
                    UserName = model.Login,
                    UserRole = (int)Enum.Parse<Role>(model.Role),
                    UserPasswordHash = HashPasswordHelper.HashPassword(model.Password),
                };


                return new BaseResponse<Users>()
                {
                    Data = user,
                    Description = "Пользователь добавлен",
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"[UserService.Create] error: {ex.Message}");
                return new BaseResponse<Users>()
                {
                    StatusCode = StatusCode.InternalServerError,
                    Description = $"Внутренняя ошибка: {ex.Message}"
                };
            }
        }
        public async Task<BaseResponse<bool>> AddWorker(AddWorkerViewModel model)
        {
            try
            {
                var worker = await _userRepository.GetAll().FirstOrDefaultAsync(x => x.UserLogin == model.Login);
                if (worker != null)
                {
                    return new BaseResponse<bool>()
                    {
                        Description = "Сотрудник с таким логином уже есть",
                        StatusCode = StatusCode.AlreadyExists
                    };
                }
                worker = new Users()
                {
                    UserSurname = model.Surname,
                    UserPhonenumber = model.Phone,
                    UserPasswordHash = HashPasswordHelper.HashPassword(model.Password),
                    UserEmail = model.Email,
                    UserLogin = model.Login,
                    UserRole = model.UserRole,
                    UserName=model.Name
                };
                await _userRepository.Create(worker);
                return new BaseResponse<bool>()
                {
                    Data = true,
                    Description = "Сотрудник добавлен",
                    StatusCode = StatusCode.OK
                };

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"[UserService.AddWorker] error: {ex.Message}");
                return new BaseResponse<bool>()
                {
                    StatusCode = StatusCode.InternalServerError,
                    Description = $"Внутренняя ошибка: {ex.Message}"
                };
            }
        }
        public async Task<BaseResponse<bool>> DeleteUser(long id)
        {
            try
            {
                var user = await _userRepository.GetAll().FirstOrDefaultAsync(x => x.UserId == id);
                if (user == null)
                {
                    return new BaseResponse<bool>
                    {
                        StatusCode = StatusCode.NotFound,
                        Data = false
                    };
                }
                await _userRepository.Delete(user);
                _logger.LogInformation($"[UserService.DeleteUser] пользователь удален");

                return new BaseResponse<bool>
                {
                    StatusCode = StatusCode.OK,
                    Data = true
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"[UserSerivce.DeleteUser] error: {ex.Message}");
                return new BaseResponse<bool>()
                {
                    StatusCode = StatusCode.InternalServerError,
                    Description = $"Внутренняя ошибка: {ex.Message}"
                };
            }
        }

        public async Task<BaseResponse<List<Users>>> GetAll()
        {
            try
            {
                var users = await _userRepository.GetAll().ToListAsync();

                _logger.LogInformation($"[UserService.GetAll] получено элементов {users.Count}");
                return new BaseResponse<List<Users>>()
                {
                    Data = users,
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"[UserService.GetAll] error: {ex.Message}");
                return new BaseResponse<List<Users>>()
                {
                    StatusCode = StatusCode.InternalServerError,
                    Description = $"Внутренняя ошибка: {ex.Message}"
                };
            }
        }

        public async Task<BaseResponse<List<Roles>>> GetRoles()
        {
            try
            {
                var roles = await _rolesRepository.GetAll().ToListAsync();
                if (roles == null)
                {
                    return new BaseResponse<List<Roles>>()
                    {
                        Description = "Роли не найдены",
                        StatusCode = StatusCode.InternalServerError
                    };
                }
                return new BaseResponse<List<Roles>>()
                {
                    Data=roles,
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<List<Roles>>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<BaseResponse<IEnumerable<UserViewModel>>> GetUsers()
        {
            try
            {
                var users = await _userRepository.GetAll()
                    .Select(x => new UserViewModel()
                    {
                        Id = x.UserId,
                        Login = x.UserName,
                        Role = x.UserRoleNavigation.RoleName
                    })
                    .ToListAsync();

                _logger.LogInformation($"[UserService.GetUsers] получено элементов {users.Count}");
                return new BaseResponse<IEnumerable<UserViewModel>>()
                {
                    Data = users,
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"[UserSerivce.GetUsers] error: {ex.Message}");
                return new BaseResponse<IEnumerable<UserViewModel>>()
                {
                    StatusCode = StatusCode.InternalServerError,
                    Description = $"Внутренняя ошибка: {ex.Message}"
                };
            }
        }
    }
}
