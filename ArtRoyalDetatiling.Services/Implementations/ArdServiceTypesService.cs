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
    public class ArdServiceTypesService : IArdServiceTypesService
    {
        private readonly IBaseRepository<ServiceType> _serviceTypesRepository;
        private readonly ILogger<ArdServiceTypesService> _logger;

        public ArdServiceTypesService(IBaseRepository<ServiceType> serviceTypesRepository,
            ILogger<ArdServiceTypesService> logger)
        {
            _serviceTypesRepository = serviceTypesRepository;
            _logger = logger;
        }
        public async Task<IBaseResponse<ServiceType>> Create(string name)
        {
            try
            {
                var serviceType = await _serviceTypesRepository.GetAll().FirstOrDefaultAsync(x => x.TypeName.Equals(name));
                if (serviceType != null)
                {
                    return new BaseResponse<ServiceType>()
                    {
                        Description = "Такой тип услуги уже имеется",
                        StatusCode = StatusCode.AlreadyExists
                    };
                }
                serviceType = new ServiceType()
                {
                    TypeName = name,
                };
                return new BaseResponse<ServiceType>()
                {
                    Data = serviceType,
                    Description = "Услуга добавлена",
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"[ArdServiceTypesService.Create] error: {ex.Message}");
                return new BaseResponse<ServiceType>()
                {
                    StatusCode = StatusCode.InternalServerError,
                    Description = $"Внутренняя ошибка: {ex.Message}"
                };
            }
        }

        public async Task<IBaseResponse<bool>> DeleteServiceType(long id)
        {
            try
            {
                var serviceType = await _serviceTypesRepository.GetAll().FirstOrDefaultAsync(x => x.IdType==id);
                if (serviceType == null)
                {
                    return new BaseResponse<bool>
                    {
                        StatusCode = StatusCode.NotFound,
                        Data = false
                    };
                }
                await _serviceTypesRepository.Delete(serviceType);
                _logger.LogInformation($"[ArdServiceTypesService.DeleteServiceType] пользователь удален");

                return new BaseResponse<bool>
                {
                    StatusCode = StatusCode.OK,
                    Data = true
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"[ArdServiceTypesService.Create] error: {ex.Message}");
                return new BaseResponse<bool>()
                {
                    StatusCode = StatusCode.InternalServerError,
                    Description = $"Внутренняя ошибка: {ex.Message}"
                };
            }
        }

        public async Task<BaseResponse<List<ServiceType>>> GetServiceTypes()
        {
            try
            {
                var serviceTypes = await _serviceTypesRepository.GetAll().ToListAsync();
                if (serviceTypes == null)
                {
                    return new BaseResponse<List<ServiceType>>()
                    {
                        Description = "Услуги не найдены",
                        StatusCode = StatusCode.InternalServerError
                    };
                }
                return new BaseResponse<List<ServiceType>>()
                {
                    Data = serviceTypes,
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<List<ServiceType>>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
    }
}
