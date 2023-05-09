using ArtRoyalDetailing.Domain.Response;
using ArtRoyalDetailing.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ArtRoyalDetailing.Services.Interfaces
{
    public interface IArdServicesService
    {
        Task<BaseResponse<bool>> RenameService(int serviceId,string newName);
        Task<BaseResponse<bool>> ChangeCost(int serviceId, string classAuto, string cost);
        Task<BaseResponse<bool>> CreateService(AddServiceViewModel model);
        Task<BaseResponse<bool>> RemoveService(int serviceId);
    }
}
