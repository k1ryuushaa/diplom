using ArtRoyalDetailing.Database.Interfaces;
using ArtRoyalDetailing.Domain.Models;
using ArtRoyalDetailing.Domain.Response;
using ArtRoyalDetailing.Domain.ViewModels;
using ArtRoyalDetatiling.Services.Interfaces;
using ArtRoyalDetatiling;
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
    public class WorkersShedulerService : IWorkersShedulerService
    {
        private readonly ILogger<WorkersShedulerService> _logger;
        private readonly IBaseRepository<WorkersSheduler> _shedulerRepository;
        private readonly IBaseRepository<Users> _userRepository;
        
        public WorkersShedulerService(ILogger<WorkersShedulerService> logger, IBaseRepository<WorkersSheduler> shedulerRepository, IBaseRepository<Users> userRepository)
        {
            _logger = logger;
            _shedulerRepository = shedulerRepository;
            _userRepository = userRepository;
        }
        private DateTime DateDestruct(string date)
        {
            DateTime _date = new DateTime(int.Parse(date.Split('.')[2]), int.Parse(date.Split('.')[1]), int.Parse(date.Split('.')[0]));
            return _date;
        }
        private TimeSpan[] TimeDestruct(string time)
        {
            TimeSpan[] _time = new TimeSpan[]{ new TimeSpan(int.Parse(time.Split(':', '-')[0]), int.Parse(time.Split(':', '-')[1]),0), 
                                               new TimeSpan(int.Parse(time.Split(':','-')[2]), int.Parse(time.Split(':', '-')[3]),0)};
            return _time;
        }
        public async Task<IBaseResponse<bool>> CreateEnroll(int workerId, string date, string time)
        {
            try
            {
                var user = await _userRepository.GetAll().FirstOrDefaultAsync(x => x.UserId == workerId);
                DateTime _date = DateDestruct(date);
                TimeSpan[] _time = TimeDestruct(time);
                var sheduler = _shedulerRepository.GetAll().FirstOrDefault(x => x.IdWorker == workerId && x.DateDay.Value.Date == _date);
                if (sheduler != null)
                {
                    await _shedulerRepository.Delete(sheduler);
                    return new BaseResponse<bool>()
                    {
                        Description = "Вы отменили запись",
                        StatusCode = StatusCode.AlreadyExists
                    };
                }
                if(user.UserRole==(int)Role.Admin)
                {
                    sheduler = _shedulerRepository.GetAll().FirstOrDefault(x => x.IdWorkerNavigation.UserRole==(int)Role.Admin&& x.DateDay.Value.Date == _date);
                    if (sheduler != null)
                    {
                        return new BaseResponse<bool>()
                        {
                            Description = "Администратор на этот день уже есть",
                            StatusCode = StatusCode.AdminAlreadyExists
                        };
                    }
                }
                if (user.UserRole == (int)Role.Washer)
                {
                    var shedulers =  _shedulerRepository.GetAll().Where(x => x.IdWorkerNavigation.UserRole == (int)Role.Washer && x.DateDay.Value.Date == _date);
                    if (shedulers != null&&shedulers.Count()>=7)
                    {
                        return new BaseResponse<bool>()
                        {
                            Description = "Мойщиков на смену достаточно",
                            StatusCode = StatusCode.ManyWashers
                        };
                    }
                }
                sheduler = new WorkersSheduler()
                {
                    IdWorker = workerId,
                    DateDay = _date,
                    TimeStart=_time[0],
                    TimeStop=_time[1]
                };

                await _shedulerRepository.Create(sheduler);
                return new BaseResponse<bool>()
                {
                    Data = true,
                    Description = "Вы записались",
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"[WorkerShedulerService.CreateEnroll] error: {ex.Message}");
                return new BaseResponse<bool>()
                {
                    StatusCode = StatusCode.InternalServerError,
                    Description = $"Внутренняя ошибка: {ex.Message}"
                };
            }
        }

        public async Task<IBaseResponse<bool>> DeleteEnroll(int workerId, string date, string time)
        {
            try
            {
                DateTime _date = DateDestruct(date);
                TimeSpan[] _time = TimeDestruct(time);
                var sheduler = await _shedulerRepository.GetAll().FirstOrDefaultAsync(x => x.IdWorker == workerId && x.DateDay.Value.Date == _date && x.TimeStart == _time[0] && x.TimeStop == _time[1]);
                if (sheduler == null)
                {
                    return new BaseResponse<bool>
                    {
                        StatusCode = StatusCode.NotFound,
                        Data = false
                    };
                }
                await _shedulerRepository.Delete(sheduler);
                _logger.LogInformation($"[WorkersShedulerService.DeleteEnroll] запись удалена");

                return new BaseResponse<bool>
                {
                    StatusCode = StatusCode.OK,
                    Data = true
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"[WorkersShedulerService.DeleteEnroll] error: {ex.Message}");
                return new BaseResponse<bool>()
                {
                    StatusCode = StatusCode.InternalServerError,
                    Description = $"Внутренняя ошибка: {ex.Message}"
                };
            }
        }

        public async Task<BaseResponse<List<WorkersSheduler>>> GetSheduler(string day,string month,string year)
        {
            try
            {
                var sheduler = await _shedulerRepository.GetAll().Include(s => s.IdWorkerNavigation).Where(s => s.DateDay.Value.Year == int.Parse(year)
                                                  && s.DateDay.Value.Day == int.Parse(day)
                                                  && s.DateDay.Value.Month == int.Parse(month)).ToListAsync();

                _logger.LogInformation($"[WorkersShedulerService.GetSheduler] получено элементов {sheduler.Count}");
                return new BaseResponse<List<WorkersSheduler>>()
                {
                    Data = sheduler,
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"[UserSerivce.GetUsers] error: {ex.Message}");
                return new BaseResponse<List<WorkersSheduler>>()
                {
                    StatusCode = StatusCode.InternalServerError,
                    Description = $"Внутренняя ошибка: {ex.Message}"
                };
            }
        }
    }
}
