using ArtRoyalDetailing.Database.Interfaces;
using ArtRoyalDetailing.Domain.Enum;
using ArtRoyalDetailing.Domain.Extensions;
using ArtRoyalDetailing.Domain.Models;
using ArtRoyalDetailing.Domain.Response;
using ArtRoyalDetailing.Domain.ViewModels;
using ArtRoyalDetailing.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtRoyalDetailing.Services.Implementations
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IBaseRepository<Contracts> _appoinmentRepository;
        private readonly IBaseRepository<ContractsServices> _appoinmentServicesRepository;
        private readonly IBaseRepository<Users> _userRepository;
        private readonly ILogger<AppointmentService> _logger;
        public AppointmentService(IBaseRepository<Users> userRepository, IBaseRepository<Contracts> appoinmentRepository, IBaseRepository<ContractsServices> appoinmentServicesRepository,
        ILogger<AppointmentService> logger)
        {
            _appoinmentRepository = appoinmentRepository;
            _appoinmentServicesRepository = appoinmentServicesRepository;
            _userRepository = userRepository;
            _logger = logger;
        }
        public async Task<BaseResponse<Contracts>> Create(AppointmentViewModel model)
        {
            try
            {
                string[] _date = model.Date.Split('.');
                var user = _userRepository.GetAll().FirstOrDefaultAsync(x => x.UserId == model.ClientId);
                var appointment = await _appoinmentRepository.GetAll().FirstOrDefaultAsync(x => x.ClientNumber == user.Result.UserPhonenumber && x.DateContract == (new DateTime(int.Parse(_date[2]),int.Parse(_date[1]),int.Parse(_date[0]))).Date);
                if (appointment != null)
                {
                    return new BaseResponse<Contracts>()
                    {
                        Description = "Вы уже записаны на этот день",
                        StatusCode = StatusCode.AlreadyExists
                    };
                }
                appointment = new Contracts()
                {
                    AutoClass = model.CarClass,
                    DateContract = new DateTime(int.Parse(_date[2]), int.Parse(_date[1]), int.Parse(_date[0])),
                    ClientNumber = user.Result.UserPhonenumber,
                    TimeContract = new TimeSpan(int.Parse(model.Hours.ToString()), int.Parse(model.Minutes.ToString()), 0),
                    EndCost = null,
                    StatusContract=1,
                    IdAdmin=null
                };
                await _appoinmentRepository.Create(appointment);
                int idAppointment = _appoinmentRepository.GetAll().FirstOrDefaultAsync(x => x.ClientNumber == user.Result.UserPhonenumber && x.DateContract == (new DateTime(int.Parse(_date[2]), int.Parse(_date[1]), int.Parse(_date[0]))).Date).Result.IdContract;
                foreach (var service in model.Services)
                {
                    var appointmentServices = new ContractsServices()
                    {
                        Cost = null,
                        IdContract = idAppointment,
                        IdService = service,
                        IdWasher = null
                    };
                    await _appoinmentServicesRepository.Create(appointmentServices);
                }
                return new BaseResponse<Contracts>()
                {
                    Data = appointment,
                    Description = "Запись добавлена",
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"[AppointmentService.Create] error: {ex.Message}");
                return new BaseResponse<Contracts>()
                {
                    StatusCode = StatusCode.InternalServerError,
                    Description = $"Внутренняя ошибка: {ex.Message}"
                };
            }
        }

        public async Task<BaseResponse<bool>> DeleteAppointment(int id)
        {
            try
            {
                var appointment = await _appoinmentRepository.GetAll().FirstOrDefaultAsync(x => x.IdContract==id);
                if (appointment == null)
                {
                    return new BaseResponse<bool>
                    {
                        StatusCode = StatusCode.NotFound,
                        Data = false
                    };
                }
                await _appoinmentRepository.Delete(appointment);
                _logger.LogInformation($"[AppointmentService.DeleteAppointment] запись удалена");

                return new BaseResponse<bool>
                {
                    StatusCode = StatusCode.OK,
                    Data = true
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"[AppointmentService.DeleteAppointment] error: {ex.Message}");
                return new BaseResponse<bool>()
                {
                    StatusCode = StatusCode.InternalServerError,
                    Description = $"Внутренняя ошибка: {ex.Message}"
                };
            }
        }

        public async Task<BaseResponse<bool>> EditAppointment(AdminAppointmentViewModel model)
        {

            var date = model.DateAppointment.TryGetDate().Value;
            var time = model.TimeAppointment.TryGetTime().Value;
            try
            {
                var appointment = await _appoinmentRepository.GetAll().FirstOrDefaultAsync(x => x.IdContract == model.AppointmentId);
                if (appointment == null)
                {
                    return new BaseResponse<bool>
                    {
                        StatusCode = StatusCode.NotFound,
                        Data = false
                    };
                }
                if(appointment.StatusContract!=4&&model.AppointmentStatus==4&&date.Date>=DateTime.Now.Date)
                {
                    return new BaseResponse<bool>
                    {
                        StatusCode = StatusCode.IncorrectData,
                        Description = "Нельзя поставить статус 'Завершено' на ненаступивший день"
                    };
                }
                var appointmentServicesList = await _appoinmentServicesRepository.GetAll().Where(x => x.IdContract == model.AppointmentId).ToListAsync();
                if (appointmentServicesList == null)
                {
                    return new BaseResponse<bool>
                    {
                        StatusCode = StatusCode.NotFound,
                        Data = false
                    };
                }
                if (model.DateAppointment.TryGetDate().Value==null|| model.TimeAppointment.TryGetTime().Value==null)
                {
                    return new BaseResponse<bool>
                    {
                        StatusCode = StatusCode.IncorrectData,
                        Description = "Неверная дата или время записи"
                    };
                }
                foreach (var appointmentService in appointmentServicesList)
                    await _appoinmentServicesRepository.Delete(appointmentService);
                appointment.AutoClass = model.CarClass;
                appointment.StatusContract = model.AppointmentStatus;
                appointment.IdAdmin = model.IdAdmin;
                appointment.DateContract = model.DateAppointment.TryGetDate().Value;
                appointment.TimeContract = model.TimeAppointment.TryGetTime().Value;
                await _appoinmentRepository.Update(appointment);
                for(int i=0;i<model.ServicesList.Count;i++)
                {
                    int? serviceId = null;
                    int? workerId = null;
                    int? cost = null;
                    try { serviceId = model.ServicesList[i]; } catch (Exception ex) { }
                    try { workerId = model.WorkersList[i]; } catch (Exception ex) { }
                    try { cost = model.CostList[i]; } catch (Exception ex) { }
                    await _appoinmentServicesRepository.Create(new ContractsServices()
                    {
                        IdContract=appointment.IdContract,
                        IdService=serviceId,
                        IdWasher=workerId,
                        Cost=cost
                    });
                }
                _logger.LogInformation($"[AppointmentService.EditAppointment] запись изменена");

                return new BaseResponse<bool>
                {
                    StatusCode = StatusCode.OK,
                    Data = true
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"[AppointmentService.DeleteAppointment] error: {ex.Message}");
                return new BaseResponse<bool>()
                {
                    StatusCode = StatusCode.InternalServerError,
                    Description = $"Внутренняя ошибка: {ex.Message}"
                };
            }
        }

        public async Task<BaseResponse<bool>> CreateAppointmentAdmin(AdminAppointmentToAddViewModel model)
        {

            var date = model.DateAppointment.TryGetDate().Value;
            var time = model.TimeAppointment.TryGetTime().Value;
            try
            {
                var appointment = await _appoinmentRepository.GetAll().FirstOrDefaultAsync(x => x.ClientNumber == model.ClientNumber&&x.DateContract.Value.Date==date.Date);
                if (appointment != null)
                {
                    return new BaseResponse<bool>
                    {
                        StatusCode = StatusCode.AlreadyExists,
                        Data = false
                    };
                }
                if (model.AppointmentStatus == 4 && date.Date >= DateTime.Now.Date)
                {
                    return new BaseResponse<bool>
                    {
                        StatusCode = StatusCode.IncorrectData,
                        Description = "Нельзя поставить статус 'Завершено' на ненаступивший день"
                    };
                }
                if (model.DateAppointment.TryGetDate().Value == null || model.TimeAppointment.TryGetTime().Value == null)
                {
                    return new BaseResponse<bool>
                    {
                        StatusCode = StatusCode.IncorrectData,
                        Description = "Неверная дата или время записи"
                    };
                }
                appointment = new Contracts();
                appointment.AutoClass = model.CarClass;
                appointment.ClientNumber = model.ClientNumber;
                appointment.StatusContract = model.AppointmentStatus;
                appointment.IdAdmin = model.IdAdmin;
                appointment.DateContract = model.DateAppointment.TryGetDate().Value;
                appointment.TimeContract = model.TimeAppointment.TryGetTime().Value;
                await _appoinmentRepository.Create(appointment);
                appointment= await _appoinmentRepository.GetAll().FirstOrDefaultAsync(x => x.ClientNumber == model.ClientNumber && x.DateContract.Value.Date == date.Date);
                for (int i = 0; i < model.ServicesList.Count; i++)
                {
                    int? serviceId = null;
                    int? workerId = null;
                    int? cost = null;
                    try { serviceId = model.ServicesList[i]; } catch (Exception ex) { }
                    try { workerId = model.WorkersList[i]; } catch (Exception ex) { }
                    try { cost = model.CostList[i]; } catch (Exception ex) { }
                    await _appoinmentServicesRepository.Create(new ContractsServices()
                    {
                        IdContract = appointment.IdContract,
                        IdService = serviceId,
                        IdWasher = workerId,
                        Cost = cost
                    });
                }
                _logger.LogInformation($"[AppointmentService.CreateAppointmentAdmin] запись добавлена");

                return new BaseResponse<bool>
                {
                    StatusCode = StatusCode.OK,
                    Data = true
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"[AppointmentService.CreateAppointmentAdmin] error: {ex.Message}");
                return new BaseResponse<bool>()
                {
                    StatusCode = StatusCode.InternalServerError,
                    Description = $"Внутренняя ошибка: {ex.Message}"
                };
            }
        }
        public async Task<BaseResponse<IEnumerable<Contracts>>> GetAll()
        {
            try
            {
                var appointments = await _appoinmentRepository.GetAll().Include(x=>x.IdAdminNavigation).Include(x=>x.StatusContractNavigation).ToListAsync();
                if (appointments == null)
                {
                    return new BaseResponse<IEnumerable<Contracts>>()
                    {
                        Description = "Записи не найдены",
                        StatusCode = StatusCode.InternalServerError
                    };
                }
                return new BaseResponse<IEnumerable<Contracts>>()
                {
                    Data = appointments,
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<Contracts>>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

    }
}
