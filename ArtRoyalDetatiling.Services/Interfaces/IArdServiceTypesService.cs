using ArtRoyalDetailing.Domain.Models;
using ArtRoyalDetailing.Domain.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ArtRoyalDetailing.Services.Interfaces
{
    public interface IArdServiceTypesService
    {
        Task<IBaseResponse<ServiceType>> Create(string name);

        Task<BaseResponse<List<ServiceType>>> GetServiceTypes();

        Task<IBaseResponse<bool>> DeleteServiceType(long id);
    }
}
