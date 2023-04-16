using ArtRoyalDetailing.Domain.Models;
using ArtRoyalDetailing.Domain.Response;
using ArtRoyalDetailing.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ArtRoyalDetailing.Services.Interfaces
{
    public interface IAppointmentService
    {
        Task<BaseResponse<Contracts>> Create(AppointmentViewModel model);

        Task<BaseResponse<IEnumerable<Contracts>>> GetAll();

        Task<BaseResponse<bool>> DeleteAppointment(int id);
        Task<BaseResponse<bool>> EditAppointment(AdminAppointmentViewModel model);
    }
}
