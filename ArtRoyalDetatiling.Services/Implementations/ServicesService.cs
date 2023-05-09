using ArtRoyalDetailing.Database.Interfaces;
using ArtRoyalDetailing.Domain.Enum;
using ArtRoyalDetailing.Domain.Models;
using ArtRoyalDetailing.Domain.Response;
using ArtRoyalDetailing.Domain.ViewModels;
using ArtRoyalDetailing.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtRoyalDetailing.Services.Implementations
{
    public class ServicesService : IArdServicesService
    {
        private readonly IBaseRepository<Domain.Models.Services> _servicesRepository;
        private readonly IBaseRepository<ServicesCosts> _servicesCostsRepository;
        private readonly IBaseRepository<ServiceType> _servicesTypesRepository;
        public ServicesService(IBaseRepository<Domain.Models.Services> servicesRepository, IBaseRepository<ServicesCosts> servicesCostsRepository, IBaseRepository<ServiceType> servicesTypesRepository)
        {
            _servicesRepository = servicesRepository;
            _servicesCostsRepository = servicesCostsRepository;
            _servicesTypesRepository = servicesTypesRepository;
        }
        public async Task<BaseResponse<bool>> RenameService(int serviceId, string newName)
        {
            var service = _servicesRepository.GetAll().FirstOrDefault(x => x.IdService == serviceId);
            if(service==null)
            {
                return new BaseResponse<bool>()
                {
                    Data = false,
                    Description = "Наименование услуги не изменено",
                    StatusCode = StatusCode.NotFound
                };
            }
            service.ServiceName = newName;
            await _servicesRepository.Update(service);
            return new BaseResponse<bool>()
            {
                Data = false,
                Description = "Наименование услуги изменено",
                StatusCode = StatusCode.OK
            };
        }
        
        public async Task<BaseResponse<bool>> ChangeCost(int serviceId, string classAuto, string cost)
        {
            try
            {
                var service = _servicesCostsRepository.GetAll().FirstOrDefault(x => x.IdService == serviceId && x.ClassAuto == classAuto);
                if (service == null)
                {
                    return new BaseResponse<bool>()
                    {
                        Data = false,
                        Description = "Услуга не найдена",
                        StatusCode = StatusCode.NotFound
                    };
                }
                service.Cost = cost;
                await _servicesCostsRepository.Update(service);
                return new BaseResponse<bool>()
                {
                    Data = true,
                    Description = "Стоимость изменена",
                    StatusCode = StatusCode.OK
                };
            }
            catch(Exception ex)
            {
                return new BaseResponse<bool>()
                {
                    Data = false,
                    Description = "Ошибка сервера",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<BaseResponse<bool>> CreateService(AddServiceViewModel model)
        {
            try
            {
                var service = _servicesRepository.GetAll().FirstOrDefault(x => x.ServiceName == model.ServiceName);
                if (service != null)
                {
                    return new BaseResponse<bool>()
                    {
                        Data = false,
                        Description = "Такая услуга уже существует",
                        StatusCode = StatusCode.AlreadyExists
                    };
                }
                await _servicesRepository.Create(new Domain.Models.Services()
                {
                    ServiceName = model.ServiceName,
                    ServiceType = model.ServiceType
                });
                service = _servicesRepository.GetAll().FirstOrDefault(x => x.ServiceName == model.ServiceName);
                await _servicesCostsRepository.Create(new ServicesCosts()
                {
                    IdService = service.IdService,
                    ClassAuto = "Класс А",
                    Cost = model.CostOne
                });
                await _servicesCostsRepository.Create(new ServicesCosts()
                {
                    IdService = service.IdService,
                    ClassAuto = "Класс B, C, D",
                    Cost = model.CostTwo
                });
                await _servicesCostsRepository.Create(new ServicesCosts()
                {
                    IdService = service.IdService,
                    ClassAuto = "Кроссовер/Универсал/Класс E,F",
                    Cost = model.CostThree
                });
                await _servicesCostsRepository.Create(new ServicesCosts()
                {
                    IdService = service.IdService,
                    ClassAuto = "Внедорожник",
                    Cost = model.CostFour
                });
                await _servicesCostsRepository.Create(new ServicesCosts()
                {
                    IdService = service.IdService,
                    ClassAuto = "Минивэн",
                    Cost = model.CostFive
                });
                return new BaseResponse<bool>()
                {
                    Data = true,
                    Description = "Услуга добавлена",
                    StatusCode = StatusCode.OK
                };
            }
            catch(Exception ex)
            {
                return new BaseResponse<bool>()
                {
                    Data = true,
                    Description = "Ошибка сервера",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<BaseResponse<bool>> RemoveService(int serviceId)
        {
            try
            {
                var service = _servicesRepository.GetAll().FirstOrDefault(x => x.IdService == serviceId);
                if (service == null)
                {
                    return new BaseResponse<bool>
                    {
                        Data = false,
                        Description = "Услуга не найдена",
                        StatusCode = StatusCode.NotFound
                    };
                }
                await _servicesRepository.Delete(service);
                return new BaseResponse<bool>
                {
                    Data = true,
                    Description = "Услуга удалена",
                    StatusCode = StatusCode.NotFound
                };
            }
            catch(Exception ex)
            {
                return new BaseResponse<bool>
                {
                    Data = false,
                    Description = "Ошибка сервера",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
    }
}
