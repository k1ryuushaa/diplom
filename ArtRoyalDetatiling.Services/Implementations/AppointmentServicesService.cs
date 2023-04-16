using ArtRoyalDetailing.Database.Interfaces;
using ArtRoyalDetailing.Domain.Models;
using ArtRoyalDetailing.Domain.Response;
using ArtRoyalDetailing.Domain.ViewModels;
using ArtRoyalDetailing.Services.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ArtRoyalDetailing.Services.Implementations
{
    public class AppointmentServicesService : IAppointmentServicesInterface
    {
        private readonly IBaseRepository<ServicesCosts> _servicesCostsRepository;
        private readonly IBaseRepository<ContractsServices> _appointmentServicesRepository;
        private readonly ILogger<AppointmentServicesService> _logger;
        public AppointmentServicesService(IBaseRepository<ServicesCosts> servicesCostsRepository, IBaseRepository<ContractsServices> appointmentServicesRepository,
            ILogger<AppointmentServicesService> logger)
        {
            _servicesCostsRepository = servicesCostsRepository;
            _appointmentServicesRepository = appointmentServicesRepository;
            _logger = logger;
        }

        public Task<IBaseResponse<ContractsServices>> Add(int idContract, List<int> services, int? idWasher = null)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<List<ContractsServices>>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IBaseResponse<bool>> RemoveFull(long idContract)
        {
            throw new NotImplementedException();
        }

        public Task<IBaseResponse<bool>> RemoveOne(long idService)
        {
            throw new NotImplementedException();
        }
    }
}
