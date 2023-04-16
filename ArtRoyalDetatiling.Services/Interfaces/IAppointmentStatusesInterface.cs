using ArtRoyalDetailing.Domain.Models;
using ArtRoyalDetailing.Domain.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ArtRoyalDetailing.Services.Interfaces
{
    public interface IAppointmentStatusesInterface
    {
        Task<BaseResponse<List<ContractStatuses>>> GetStatuses();
    }
}
