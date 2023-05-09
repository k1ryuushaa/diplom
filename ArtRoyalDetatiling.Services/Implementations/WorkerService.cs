using ArtRoyalDetailing.Database.Interfaces;
using ArtRoyalDetailing.Domain.Enum;
using ArtRoyalDetailing.Domain.Models;
using ArtRoyalDetailing.Domain.Response;
using ArtRoyalDetatiling.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtRoyalDetailing.Services.Implementations
{
    public class WorkerService : IWorkerService
    {
        private readonly ILogger<WorkerService> _logger;
        private readonly IBaseRepository<Users> _userRepository;
        private readonly IBaseRepository<Salary> _salaryRepository;
        private readonly IBaseRepository<Contracts> _appointmentsRepository;
        private readonly IBaseRepository<ContractsServices> _appointmentServicesRepository;
        public WorkerService(ILogger<WorkerService> logger,
                             IBaseRepository<Users> userRepository, 
                             IBaseRepository<Salary> salaryRepository,
                             IBaseRepository<Contracts> appointmentsRepository,
                             IBaseRepository<ContractsServices> appointmentServicesRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
            _salaryRepository = salaryRepository;
            _appointmentsRepository = appointmentsRepository;
            _appointmentServicesRepository = appointmentServicesRepository;
        }
        public async Task<BaseResponse<bool>> SetSalary(int workerId)
        {
            try
            {
                var worker = await _userRepository.GetAll().FirstOrDefaultAsync(x => x.UserId==workerId);
                if (worker == null)
                {
                    return new BaseResponse<bool>()
                    {
                        Data=false,
                        Description = "Сотрудник не найден",
                        StatusCode = StatusCode.NotFound
                    };
                }
                var appointments = _appointmentsRepository.GetAll().Where(a => a.DateContract > worker.Salary.DateSalary&&a.StatusContract==4).ToList();
                if (appointments == null)
                {
                    return new BaseResponse<bool>()
                    {
                        Data = false,
                        Description = "Сотрудник пока ничего не заработал",
                        StatusCode = StatusCode.NotFound
                    };
                }
                var appointmentsService = _appointmentServicesRepository.GetAll().Where(x => x.IdWasher == workerId).ToList();
                if (appointmentsService == null)
                {
                    return new BaseResponse<bool>()
                    {
                        Data = false,
                        Description = "Сотрудник пока ничего не заработал",
                        StatusCode = StatusCode.NotFound
                    };
                }
                double salary = 0;
                foreach(var appointment in appointments)
                {
                    foreach(var service in appointmentsService)
                    {
                        if (appointment.IdContract == service.IdContract)
                            salary += (double)(service.Cost.Value*0.3);
                    }
                }
                var salaryWorker = await _salaryRepository.GetAll().FirstOrDefaultAsync(x => x.WorkerId == workerId);
                if (salaryWorker == null)
                {
                    await _salaryRepository.Create(new Salary()
                    {
                        WorkerId=workerId,
                        DateSalary=DateTime.Now,
                        Salary1=(int)salary
                    });
                }
                else
                {
                    salaryWorker.DateSalary = DateTime.Now;
                    salaryWorker.Salary1 = (int)salary;
                }
                await _salaryRepository.Update(salaryWorker);


                return new BaseResponse<bool>()
                {
                    Data = true,
                    Description = Math.Round(salary,2).ToString(),
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"[WorkerService.SetSalary] error: {ex.Message}");
                return new BaseResponse<bool>()
                {
                    Data=false,
                    StatusCode = StatusCode.InternalServerError,
                    Description = $"Внутренняя ошибка: {ex.Message}"
                };
            }
        }
    }
}
