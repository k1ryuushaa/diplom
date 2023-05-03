using ArtRoyalDetailing.Domain.Models;
using ArtRoyalDetailing.Domain.Response;
using ArtRoyalDetailing.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ArtRoyalDetatiling.Services.Interfaces
{
    public interface IUserService
    {
        Task<BaseResponse<Users>> Create(UserViewModel model);

        Task<BaseResponse<List<Roles>>> GetRoles();

        Task<BaseResponse<IEnumerable<UserViewModel>>> GetUsers();
        Task<BaseResponse<List<Users>>> GetAll();

        Task<BaseResponse<bool>> DeleteUser(long id);
        Task<BaseResponse<bool>> AddWorker(AddWorkerViewModel model);
    }
}
