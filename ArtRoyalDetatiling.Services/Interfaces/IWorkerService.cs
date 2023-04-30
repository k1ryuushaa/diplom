using ArtRoyalDetailing.Domain.Models;
using ArtRoyalDetailing.Domain.Response;
using ArtRoyalDetailing.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ArtRoyalDetatiling.Services.Interfaces
{
    public interface IWorkerService
    {
        Task<BaseResponse<bool>> SetSalary(int workerId);

    }
}
