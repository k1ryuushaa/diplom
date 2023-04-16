using ArtRoyalDetailing.Database.Interfaces;
using ArtRoyalDetailing.Domain.Dictionaries;
using ArtRoyalDetailing.Domain.Enum;
using ArtRoyalDetailing.Domain.Extensions;
using ArtRoyalDetailing.Domain.Models;
using ArtRoyalDetailing.Domain.ViewModels;
using ArtRoyalDetailing.Services.Interfaces;
using ArtRoyalDetatiling.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ArtRoyalDetailing.Domain;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Word;

namespace ArtRoyalDetailing.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IBaseRepository<Domain.Models.Services> _ardServicesRepository;
        private readonly IBaseRepository<Users> _userRepository;
        private readonly IBaseRepository<ContractStatuses> _contractStatusesRepository;
        private readonly IBaseRepository<ServicesCosts> _servicesCostsRepository;
        private readonly IBaseRepository<ContractsServices> _contractServicesRepository;

        public AppointmentController(IAppointmentService appointmentService, 
               IBaseRepository<Domain.Models.Services> ardServicesService, 
               IBaseRepository<Users> userRepository, 
               IBaseRepository<ContractsServices> contractServicesRepository,
               IBaseRepository<ServicesCosts> servicesCostsRepository,
               IBaseRepository<ContractStatuses> contractStatusesRepository)
        {
            _appointmentService = appointmentService;
            _ardServicesRepository = ardServicesService;
            _userRepository = userRepository;
            _contractServicesRepository = contractServicesRepository;
            _contractStatusesRepository = contractStatusesRepository;
            _servicesCostsRepository = servicesCostsRepository;
        }

        public IActionResult Index()
        {
            ViewBag.Services = _ardServicesRepository.GetAll();
            if (User.Identity.IsAuthenticated && User.IsInRole($"{(int)Role.Client}"))
            {
                int uId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
                var user = _userRepository.GetAll().FirstOrDefault(x => x.UserId == uId);
                var appointments = _appointmentService.GetAll().Result.Data.Where(x => x.ClientNumber == user.UserPhonenumber);
                ViewBag.Appointments = appointments != null ? appointments : null;
                var services = _contractServicesRepository.GetAll().Include(x=>x.IdServiceNavigation).ToList();
                ViewBag.ContractServices = services != null ? services : null;
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateAppointment(AppointmentViewModel model)
        {
            var mod = model;
            ViewBag.day = model.Date.Split('.')[0];
            ViewBag.month = model.Date.Split('.')[1];
            ViewBag.year = model.Date.Split('.')[2];
            if (User.Identity.IsAuthenticated && User.IsInRole($"{(int)Role.Client}"))
            {
                int uId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
                var user = _userRepository.GetAll().FirstOrDefault(x => x.UserId == uId);
                var appointments = _appointmentService.GetAll().Result.Data.Where(x => x.ClientNumber == user.UserPhonenumber);
                ViewBag.Appointments = appointments != null ? appointments : null; 
                var services = _contractServicesRepository.GetAll().Include(x => x.IdServiceNavigation).ToList();
                ViewBag.ContractServices = services != null ? services : null;
            }
            ViewBag.Services = _ardServicesRepository.GetAll();
            if (ModelState.IsValid&&model.Services.Count()>0)
            {
                var response= await _appointmentService.Create(model);
                if (response.StatusCode == Domain.Enum.StatusCode.OK)
                {
                    ViewBag.Success = "Вы успешно записалиcь";
                    if (User.Identity.IsAuthenticated && User.IsInRole($"{(int)Role.Client}"))
                    {
                        int uId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
                        var user = _userRepository.GetAll().FirstOrDefault(x => x.UserId == uId);
                        var appointments = _appointmentService.GetAll().Result.Data.Where(x => x.ClientNumber == user.UserPhonenumber);
                        ViewBag.Appointments = appointments != null ? appointments : null;
                        var services = _contractServicesRepository.GetAll().Include(x => x.IdServiceNavigation).ToList();
                        ViewBag.ContractServices = services != null ? services : null;
                    }
                    return View("Index");
                }
                if (response.StatusCode == Domain.Enum.StatusCode.AlreadyExists)
                {
                    ViewBag.Error = "Вы уже записаны на этот день";
                    return View("Index");
                }
                if (response.StatusCode == Domain.Enum.StatusCode.InternalServerError)
                {
                    ViewBag.Error = "Ошибка сервера";
                    return View("Index");
                }
            }
            ViewBag.Error = "Заполните все поля для записи";
            return View("Index");
        }
        [HttpGet]
        public async Task<IActionResult> AdminAppointment()
        {
            var appointments =  _appointmentService.GetAll().Result.Data.ToList();
            ViewBag.carClasses= new DictionaryCarClass().GetClasses().ToList();
            ViewBag.workers =_userRepository.GetAll().ToList();
            ViewBag.contractStatuses= _contractStatusesRepository.GetAll().ToList();
            ViewBag.services= _ardServicesRepository.GetAll().ToList();
            ViewBag.servicesCosts= _servicesCostsRepository.GetAll().ToList();
            ViewBag.contractServices= _contractServicesRepository.GetAll().ToList();
            return View(appointments);
        }
        [HttpPost]
        public async Task<JsonResult> AdminAppointment(AdminAppointmentViewModel model)
        {
            var response = await _appointmentService.EditAppointment(model);
            return Json(response);
        }
        [HttpPost]
        public async Task<bool> CreateReceipt(int appointmentId)
        {
            var appointment = _appointmentService.GetAll().Result.Data.FirstOrDefault(x => x.IdContract == appointmentId);
            if (appointment == null) return false;
            var appointmentServices = _contractServicesRepository.GetAll().Where(x => x.IdContract == appointmentId).ToList();
            if (appointmentServices == null) return false;
            Document document = null;
            Application application = new Application();
            String fileName = System.IO.Path.GetTempFileName();
            System.IO.File.WriteAllBytes(fileName, Properties.Resources.receipt);
            document = application.Documents.Open(fileName);
            document.Bookmarks["Admin"].Range.Text = " " + User.Identity.Name;
            document.Bookmarks["Date"].Range.Text = DateTime.Now.ToShortDateString();
            document.Bookmarks["AppointmentNumber"].Range.Text = appointmentId.ToString();
            int EndCost = 0;
            for (int i = 2; i <= appointmentServices.Count() + 1; i++)
            {
                document.Tables[1].Rows[i].Cells[1].Range.Text = appointmentServices[i - 2].IdServiceNavigation.ServiceName;
                document.Tables[1].Rows[i].Cells[2].Range.Text = appointmentServices[i - 2].IdWasherNavigation.UserSurname + " " + appointmentServices[i - 2].IdWasherNavigation.UserName;
                document.Tables[1].Rows[i].Cells[3].Range.Text = appointmentServices[i - 2].Cost.Value.ToString() + "руб.";
                EndCost += appointmentServices[i - 2].Cost.Value;
                if (i < appointmentServices.Count() + 1)
                {
                    Object oMissing = System.Reflection.Missing.Value;
                    document.Tables[1].Rows.Add(ref oMissing);
                }

            }
            document.Bookmarks["EndCost"].Range.Text = EndCost.ToString() + "руб.";
            application.Visible = true;
            return true;
        }
    }
}
