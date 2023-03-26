using ArtRoyalDetailing.Database.Interfaces;
using ArtRoyalDetailing.Database.Repositories;
using ArtRoyalDetailing.Domain.Models;
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
            services.AddScoped<IBaseRepository<Users>, UserRepository>();
        }

        public static void InitializeServices(this IServiceCollection services)
        {
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IUserService, UserService>();
        }
    }
}
