using ArtRoyalDetailing.Domain.Models;
using ArtRoyalDetailing.Domain.Response;
using ArtRoyalDetailing.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ArtRoyalDetatiling.Services.Interfaces
{
    public interface IWorkersShedulerService
    {
        Task<IBaseResponse<WorkersSheduler>> CreateEnroll(int workerId,string date,string time);

        Task<BaseResponse<List<WorkersSheduler>>> GetSheduler(string day,string month,string year);

        Task<IBaseResponse<bool>> DeleteEnroll(int workerId, string date, string time);
    }
}
