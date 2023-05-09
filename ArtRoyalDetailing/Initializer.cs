using ArtRoyalDetailing.Database.Interfaces;
using ArtRoyalDetailing.Database.Repositories;
using ArtRoyalDetailing.Domain.Models;
using ArtRoyalDetailing.Services.Implementations;
using ArtRoyalDetailing.Services.Interfaces;
using ArtRoyalDetatiling.Services.Implementations;
using ArtRoyalDetatiling.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtRoyalDetailing
{
    public static class Initializer
    {
        public static void InitializeRepositories(this IServiceCollection services)
        {
            services.AddScoped<IBaseRepository<Roles>, RoleRepository>();
            services.AddScoped<IBaseRepository<Users>, UserRepository>();
            services.AddScoped<IBaseRepository<WorkersSheduler>, WorkersShedulerRepository>();
            services.AddScoped<IBaseRepository<ContractsServices>, AppointmentServicesRepository>();
            services.AddScoped<IBaseRepository<Contracts>, AppointmentsRepository>();
            services.AddScoped<IBaseRepository<Salary>, SalaryRepository>();
            services.AddScoped<IBaseRepository<ServiceType>, ServiceTypesRepository>();
            services.AddScoped<IBaseRepository<ContractStatuses>, ContractStatusesRepository>();
            services.AddScoped<IBaseRepository<ServicesCosts>, ServicesCostsRepository>();
            services.AddScoped<IBaseRepository<ArtRoyalDetailing.Domain.Models.Services>, ArdServicesRepository>();
        }

        public static void InitializeServices(this IServiceCollection services)
        {
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IWorkersShedulerService, WorkersShedulerService>();
            services.AddScoped<IWorkerService, WorkerService>();
            services.AddScoped<IArdServiceTypesService, ArdServiceTypesService>();
            services.AddScoped<IAppointmentService, AppointmentService>();
            services.AddScoped<IArdServicesService, ServicesService>();
        }
    }
}
