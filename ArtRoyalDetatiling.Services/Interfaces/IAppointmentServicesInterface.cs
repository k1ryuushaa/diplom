using ArtRoyalDetailing.Domain.Models;
using ArtRoyalDetailing.Domain.Response;
using ArtRoyalDetailing.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ArtRoyalDetailing.Services.Interfaces
{
    public interface IAppointmentServicesInterface
    {
        Task<IBaseResponse<ContractsServices>> Add(int idContract,List<int> services,int? idWasher=null);

        Task<BaseResponse<List<ContractsServices>>> GetAll();

        Task<IBaseResponse<bool>> RemoveOne(long idService);

        Task<IBaseResponse<bool>> RemoveFull(long idContract);
    }
}
