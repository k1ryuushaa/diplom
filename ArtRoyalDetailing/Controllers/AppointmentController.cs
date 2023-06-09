using ArtRoyalDetailing.Database.Interfaces;
using ArtRoyalDetailing.Domain.Dictionaries;
using ArtRoyalDetailing.Domain.Enum;
using ArtRoyalDetailing.Domain.Extensions;
using ArtRoyalDetailing.Domain.Models;
using ArtRoyalDetailing.Domain.ViewModels;
using ArtRoyalDetailing.Services.Interfaces;
using ArtRoyalDetatiling.Services.Interfaces;
using OpenXmlPowerTools;
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
using ArtRoyalDetailing.Classes;
using System.Reflection;
using System.Net.Http;
using DocumentFormat.OpenXml.Packaging;
using System.Xml.Linq;
using Microsoft.AspNetCore.Authorization;

namespace ArtRoyalDetailing.Controllers
{
    [Authorize]
    public class AppointmentController : Controller
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IBaseRepository<Contracts> _appointmentsRepository;
        private readonly IBaseRepository<Domain.Models.Services> _ardServicesRepository;
        private readonly IBaseRepository<Users> _userRepository;
        private readonly IBaseRepository<ContractStatuses> _contractStatusesRepository;
        private readonly IBaseRepository<ServicesCosts> _servicesCostsRepository;
        private readonly IBaseRepository<ServiceType> _servicesTypesRepository;
        private readonly IBaseRepository<ContractsServices> _contractServicesRepository;

        public AppointmentController(IAppointmentService appointmentService, 
               IBaseRepository<Domain.Models.Services> ardServicesService, 
               IBaseRepository<Users> userRepository, 
               IBaseRepository<ContractsServices> contractServicesRepository,
               IBaseRepository<ServicesCosts> servicesCostsRepository,
               IBaseRepository<Contracts> appointmentsRepository,
               IBaseRepository<ServiceType> servicesTypesRepository,
               IBaseRepository<ContractStatuses> contractStatusesRepository)
        {
            _appointmentService = appointmentService;
            _ardServicesRepository = ardServicesService;
            _userRepository = userRepository;
            _appointmentsRepository = appointmentsRepository;
            _contractServicesRepository = contractServicesRepository;
            _contractStatusesRepository = contractStatusesRepository;
            _servicesCostsRepository = servicesCostsRepository;
            _servicesTypesRepository = servicesTypesRepository;
        }
        public IActionResult Index()
        {
            ViewBag.Services = _ardServicesRepository.GetAll().ToList();
            if (User.Identity.IsAuthenticated && User.IsInRole($"{(int)Role.Client}"))
            {
                int uId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
                var user = _userRepository.GetAll().FirstOrDefault(x => x.UserId == uId);
                var appointments = _appointmentService.GetAll().Result.Data.Where(x => x.ClientNumber == user.UserPhonenumber);
                ViewBag.Appointments = appointments != null ? appointments : null;
                var services = _contractServicesRepository.GetAll().Include(x=>x.IdServiceNavigation).ToList();
                ViewBag.ContractServices = services != null ? services : null;
                ViewBag.serviceTypes = _servicesTypesRepository.GetAll().ToList();
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateAppointment(AppointmentViewModel model)
        {
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
                ViewBag.serviceTypes = _servicesTypesRepository.GetAll().ToList();
            }
            ViewBag.Services = _ardServicesRepository.GetAll().ToList();
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
                        ViewBag.serviceTypes = _servicesTypesRepository.GetAll().ToList();
                    }
                    return View("Index");
                }
                if (response.StatusCode == Domain.Enum.StatusCode.AlreadyExists)
                {
                    ViewBag.Error = response.Description;
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
        public async Task<IActionResult> AdminAppointment(int? appointmentId = null,string clientNumber=null,int? appointmentStatusId=null,int page=1,DateTime? dateIn=null, DateTime? dateOut = null)
        {
            ViewBag.IdStatus = appointmentStatusId;
            ViewBag.AppointmentId = appointmentId;
            ViewBag.ClientNumber = clientNumber;
            var appointments = _appointmentService.GetAll().Result.Data.ToList();
            if (appointmentId.HasValue)
                appointments = appointments.Where(x => x.IdContract == appointmentId.Value).ToList();
            if (!string.IsNullOrEmpty(clientNumber))
                appointments = appointments.Where(x => x.ClientNumber.Contains(clientNumber)).ToList();
            if (appointmentStatusId.HasValue)
                appointments = appointments.Where(x =>x.StatusContract==appointmentStatusId.Value).ToList();
            if(dateIn.HasValue)
                appointments = appointments.Where(x => x.DateContract.Value.Date>=dateIn.Value.Date&& x.DateContract.Value.Date <= (dateOut.HasValue?dateOut.Value.Date:DateTime.Now.Date)&&x.StartTime>=dateIn.Value.TimeOfDay&& x.EndTime <= (dateOut.HasValue ? dateOut.Value.TimeOfDay : DateTime.Now.TimeOfDay)).ToList();
            ViewBag.carClasses = new DictionaryCarClass().GetClasses().ToList();
            ViewBag.workers = _userRepository.GetAll().ToList();
            ViewBag.contractStatuses = _contractStatusesRepository.GetAll().ToList();
            ViewBag.services = _ardServicesRepository.GetAll().ToList();
            ViewBag.DateIn = dateIn;
            ViewBag.DateOut = dateIn.HasValue?(dateOut.HasValue?dateOut:DateTime.Now):dateIn;
            ViewBag.serviceTypes = _servicesTypesRepository.GetAll().ToList();
            ViewBag.servicesCosts = _servicesCostsRepository.GetAll().ToList();
            ViewBag.contractServices = _contractServicesRepository.GetAll().ToList();

            const int pageSize = 5;
            if (page < 1)
                page = 1;
            int recsCount = appointments.Count();
            var pager = new Pager(recsCount, page, pageSize);
            int recSkip = (page - 1) * pageSize;
            var data = appointments.Skip(recSkip).Take(pager.PageSize).ToList();
            ViewBag.Pager = pager;
            return View(data);
        }
        [HttpPost]
        public async Task<JsonResult> EditAppointment(AdminAppointmentViewModel model)
        {
            var response = await _appointmentService.EditAppointment(model);
            return Json(response);
        }
        [HttpPost]
        public async Task<JsonResult> CreateAppointmentAdmin(AdminAppointmentToAddViewModel model)
        {
            var response = await _appointmentService.CreateAppointmentAdmin(model);
            return Json(response);
        }
        [HttpPost]
        public async Task<JsonResult> DeleteAppointment(int appointmentId)
        {
            var response = await _appointmentService.DeleteAppointment(appointmentId);
            return Json(response);
        }
        [HttpPost]
        public async Task<IActionResult> CreateReceipt(int appointmentId)
        {
            var appointment = _appointmentService.GetAll().Result.Data.FirstOrDefault(x => x.IdContract == appointmentId);
            if (appointment == null) return null;
            var appointmentServices = _contractServicesRepository.GetAll().Where(x => x.IdContract == appointmentId).ToList();
            if (appointmentServices == null) return null;
            Document document = null;
            Application application = new Application();
            String fileName = System.IO.Path.GetTempFileName();
            System.IO.File.WriteAllBytes(fileName, Properties.Resources.receipt);
            document = application.Documents.Open(fileName);
            document.Bookmarks["Admin"].Range.Text = " " + User.Identity.Name;
            document.Bookmarks["Date"].Range.Text = DateTime.Now.ToShortDateString();
            document.Bookmarks["AppointmentDate"].Range.Text = appointment.DateContract.Value.ToShortDateString();
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
                    Object oMissing = Missing.Value;
                    document.Tables[1].Rows.Add(ref oMissing);
                }

            }
            document.Bookmarks["EndCost"].Range.Text = EndCost.ToString() + "руб.";
            application.ActiveDocument.WebOptions.AllowPNG = true;
            object file = Path.GetTempFileName();
            document.SaveAs(file,WdSaveFormat.wdFormatHTML);
            document.Close();
            return Json(System.IO.File.ReadAllText(file.ToString()));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAct(int appointmentId)
        {
            var appointment = _appointmentService.GetAll().Result.Data.FirstOrDefault(x => x.IdContract == appointmentId);
            var client = _userRepository.GetAll().FirstOrDefault(x => x.UserPhonenumber.Equals(appointment.ClientNumber));
            if (appointment == null) return null;
            var actData = new PrintActModel()
            {
                AdminName = User.Identity.Name,
                ClientName = client.UserSurname + " " + client.UserName,
                CarClass = appointment.AutoClass,
                DateGet = appointment.DateContract.Value.ToShortDateString(),
                GosNumber = appointment.GosNumber,
                OrderNumber = appointment.IdContract.ToString(),
                PhoneClient = appointment.ClientNumber
            };
            return PartialView("PrintAct",actData);
        }
        [HttpPost]
        public IActionResult GetTimeModal(DateTime date)
        {
            var appointments = _appointmentsRepository.GetAll();
            List<string> times = new List<string>();
            TimeSpan startTime= new TimeSpan(10,0,0);
            TimeSpan endTime= new TimeSpan(20,0,0);
            for(var time = startTime; time <= endTime; time = time.Add(TimeSpan.FromHours(2)))
            {
                //if(appointments.FirstOrDefault(x => (x.StartTime.Value > time && x.StartTime.Value <= time.Add(TimeSpan.FromHours(2)) || x.EndTime.Value > time && x.EndTime.Value < time.Add(TimeSpan.FromHours(2))) &&x.DateContract.Value.Date==date.Date)!=null)
                if(appointments.FirstOrDefault(x => x.StartTime.Value == time&&x.EndTime==time.Add(TimeSpan.FromHours(2)) &&x.DateContract.Value.Date==date.Date)!=null)
                    continue; 
                times.Add(time.ToString(@"hh\:mm")+" - "+time.Add(TimeSpan.FromHours(2)).ToString(@"hh\:mm"));
            }
            return PartialView("PartialTimeChange", times);
        }
        [HttpGet]
        public async Task<IActionResult> WasherAppointment()
        {
            var appointmentServices = _contractServicesRepository.GetAll().Where(x => x.IdWasher == int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value)&&(x.IdContractNavigation.StatusContract==2|| x.IdContractNavigation.StatusContract == 3));
            if (appointmentServices == null)
                return View();
            var appointments = _appointmentsRepository.GetAll().Where(x => appointmentServices.Select(x => x.IdContract).Contains(x.IdContract)).ToList();
            ViewBag.contractServices = appointmentServices.ToList();
            return View(appointments);
        }
    }
}
