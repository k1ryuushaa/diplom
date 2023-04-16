using ArtRoyalDetailing.Database.Interfaces;
using ArtRoyalDetailing.Domain.Enum;
using ArtRoyalDetailing.Domain.Models;
using ArtRoyalDetailing.Domain.Response;
using ArtRoyalDetailing.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ArtRoyalDetailing.Services.Implementations
{
    public class AppointmentStatusesService : IAppointmentStatusesInterface
    {
        private readonly IBaseRepository<ContractStatuses> _appoinmentStatusesRepository;
        private readonly ILogger<AppointmentService> _logger;
        public AppointmentStatusesService(IBaseRepository<ContractStatuses> appoinmentStatusesRepository,
            ILogger<AppointmentService> logger)
        {
            _appoinmentStatusesRepository = appoinmentStatusesRepository;
            _logger = logger;
        }
        public async Task<BaseResponse<List<ContractStatuses>>> GetStatuses()
        {
            try
            {
                var statuses = await _appoinmentStatusesRepository.GetAll().ToListAsync();
                if (statuses == null)
                {
                    return new BaseResponse<List<ContractStatuses>>()
                    {
                        Description = "Статусы не найдены",
                        StatusCode = StatusCode.NotFound
                    };
                }
                return new BaseResponse<List<ContractStatuses>>()
                {
                    Data = statuses,
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<List<ContractStatuses>>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
    }
}
