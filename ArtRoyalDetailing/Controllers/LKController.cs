using ArtRoyalDetailing.Database.Interfaces;
using ArtRoyalDetailing.Domain.Enum;
using ArtRoyalDetailing.Domain.Models;
using ArtRoyalDetailing.Domain.ViewModels;
using ArtRoyalDetailing.Services.Interfaces;
using ArtRoyalDetatiling.Services.Interfaces;
using DocumentFormat.OpenXml.Packaging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Office.Interop.Word;
using OpenXmlPowerTools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ArtRoyalDetailing.Controllers
{
    public class LKController : Controller
    {

        private readonly IBaseRepository<Users> _userRepository;
        private readonly IBaseRepository<Roles> _rolesRepository;
        private readonly IBaseRepository<Domain.Models.Services> _servicesRepository;
        private readonly IBaseRepository<Contracts> _appointmentsRepository;
        private readonly IBaseRepository<Salary> _salaryRepository;
        private readonly IBaseRepository<ServiceType> _serviceTypesRepository;
        private readonly IBaseRepository<ContractsServices> _appointmentServicesRepository;
        private readonly IWorkerService _workerService;
        private readonly IArdServicesService _servicesService;
        private readonly IUserService _userService;
        public LKController(IBaseRepository<Domain.Models.Services> servicesRepository,
                            IBaseRepository<Users> userRepository,
                            IBaseRepository<Salary> salaryRepository,
                            IBaseRepository<Contracts> appointmentsRepository,
                            IBaseRepository<ContractsServices> appointmentServicesRepository,
                            IBaseRepository<ServiceType> serviceTypesRepository,
                            IWorkerService workerService,
                            IBaseRepository<Roles> rolesRepository,
                            IArdServicesService servicesService,
                            IUserService userService)
        {
            _rolesRepository = rolesRepository;
            _userRepository = userRepository;
            _salaryRepository = salaryRepository;
            _appointmentsRepository = appointmentsRepository;
            _appointmentServicesRepository = appointmentServicesRepository;
            _servicesRepository = servicesRepository;
            _workerService = workerService;
            _userService = userService;
            _servicesService= servicesService;
            _serviceTypesRepository = serviceTypesRepository;
        }
        public IActionResult Index()
        {
            if(User.Identity.IsAuthenticated && User.IsInRole($"{(int)Role.Washer}"))
            {
                var washer = _userRepository.GetAll().FirstOrDefault(x => x.UserId == int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value));
                ViewBag.lastSalaryDate = washer.Salary.DateSalary.Value.ToShortDateString();
                ViewBag.lastSalary = washer.Salary.Salary1.Value.ToString();
                var appointments = _appointmentsRepository.GetAll().Where(a => a.DateContract > washer.Salary.DateSalary && a.StatusContract == 4).ToList();
                if (appointments == null)
                {
                    return View("LK");
                }
                var appointmentsService = _appointmentServicesRepository.GetAll().Where(x => x.IdWasher == washer.UserId).ToList();
                if (appointmentsService == null)
                {
                    return View("LK");
                }
                double salary = 0;
                foreach (var appointment in appointments)
                {
                    foreach (var service in appointmentsService)
                    {
                        if (appointment.IdContract == service.IdContract)
                            salary += (double)(service.Cost.Value * 0.3);
                    }
                }
                ViewBag.currentSalary = salary.ToString();
            }
            return View("LK");
        }
        public IActionResult GetSalaryPage()
        {
            var workers = _userRepository.GetAll().Where(w=>w.UserRoleNavigation.RoleId == (int)Role.Washer).ToList();
            return PartialView("PartialSalary", workers);
        }
        public IActionResult GetWorkersTable()
        {
            var workers = _userRepository.GetAll().Where(w => w.UserRoleNavigation.RoleId == (int)Role.Washer|| w.UserRoleNavigation.RoleId == (int)Role.Admin).ToList();
            return PartialView("PartialWorkersTable", workers);
        }
        public IActionResult GetWorkersPage()
        {
            ViewBag.Roles = _rolesRepository.GetAll().ToList();
            return PartialView("PartialWorkersPage");
        }
        public IActionResult GetAddServicePage()
        {
            var serviceTypes = _serviceTypesRepository.GetAll().ToList();
            return PartialView("PartialAddService",serviceTypes);
        }
        public IActionResult GetSalaryForWorker(int workerId)
        {
            var worker = _userRepository.GetAll().FirstOrDefault(x=>x.UserId==workerId);
            var appointments = _appointmentsRepository.GetAll().Where(a=>a.DateContract>worker.Salary.DateSalary&&a.StatusContract==4).ToList();
            ViewBag.Appointments = appointments;
            ViewBag.LastSalary = _salaryRepository.GetAll().FirstOrDefault(x => x.WorkerId == workerId);
            ViewBag.AppointmentsServices = _appointmentServicesRepository.GetAll().Where(x=>x.IdWasher==workerId&&appointments.Select(x=>x.IdContract).ToList().Contains((int)x.IdContract)).ToList();
            return PartialView("PartialSalaryForWorker", worker);
        }
        public async Task<IActionResult> SetSalary(int workerId)
        {

            var worker = _userRepository.GetAll().FirstOrDefault(x => x.UserId == workerId);
            if (worker == null) return null;
            DateTime lastSalryDate = worker.Salary.DateSalary.Value;
            var response = await _workerService.SetSalary(workerId);
            if(response.Data==true)
            {
                Document document = null;
                Application application = new Application();
                String fileName = System.IO.Path.GetTempFileName();
                System.IO.File.WriteAllBytes(fileName, Properties.Resources.salaryWorker);
                document = application.Documents.Open(fileName);
                document.Bookmarks["FI"].Range.Text = " " + worker.UserSurname+" "+worker.UserName;
                document.Bookmarks["dateSalary"].Range.Text = DateTime.Now.ToShortDateString();
                document.Bookmarks["periodOT"].Range.Text = lastSalryDate.ToShortDateString();
                document.Bookmarks["periodDO"].Range.Text = DateTime.Now.ToShortDateString();
                document.Bookmarks["numberDoc"].Range.Text = worker.UserId.ToString() + DateTime.Now.ToShortDateString().Replace(".", "");
                document.Bookmarks["tabNumber"].Range.Text = worker.UserId.ToString("D6");
                document.Bookmarks["salary"].Range.Text = Math.Round(double.Parse(response.Description),2).ToString();
                object file = Path.GetTempFileName();
                document.SaveAs(file);
                document.Close();
                string docHTML;
                byte[] byteArray = System.IO.File.ReadAllBytes(file.ToString());
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    memoryStream.Write(byteArray, 0, byteArray.Length);
                    using (WordprocessingDocument doc = WordprocessingDocument.Open(memoryStream, true))
                    {
                        HtmlConverterSettings settings = new HtmlConverterSettings()
                        {
                            PageTitle = "My Page Title"
                        };
                        XElement html = HtmlConverter.ConvertToHtml(doc, settings);

                        docHTML=html.ToStringNewLineOnAttributes();
                    }
                }
                response.Description = docHTML;
            }
            return Json(response);
        }
        public async Task<IActionResult> RemoveWorker(int workerId)
        {
            var response = await _userService.DeleteUser(workerId);
            return Json(response);
        }
        public async Task<IActionResult> AddWorker(AddWorkerViewModel model)
        {
            var response = await _userService.AddWorker(model);
            return Json(response);
        }
        public IActionResult GetProfilePage()
        {
            var user = _userRepository.GetAll().FirstOrDefault(x=>x.UserId==int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value));
            return PartialView("PartialMyProfile",user);
        }
        public async Task<IActionResult> EditMyProfile(EditUserViewModel model)
        {
            var response = await _userService.EditUser(model);
            return Json(response);
        }
        public async Task<IActionResult> AddService(AddServiceViewModel model)
        {
            var response = await _servicesService.CreateService(model);
            return Json(response);
        }
        public IActionResult GetWasherHistory()
        {
            var appointmentServices = _appointmentServicesRepository.GetAll().Where(x => x.IdWasher == int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value) && x.IdContractNavigation.StatusContract == 4);
            if (appointmentServices == null)
                return View();
            var appointments = _appointmentsRepository.GetAll().Where(x => appointmentServices.Select(x => x.IdContract).Contains(x.IdContract)&&x.StatusContract==4).ToList();
            ViewBag.contractServices = appointmentServices.ToList();
            return PartialView("PartialWasherHistory", appointments);
        }
        public IActionResult GetClientHistory()
        {
            var user = _userRepository.GetAll().FirstOrDefault(x => x.UserId == int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value));
            var appointments = _appointmentsRepository.GetAll().Where(x => x.ClientNumber.Equals(user.UserPhonenumber)&&x.StatusContract==4).ToList();
            if (appointments == null)
                return View();
            var appointmentServices = _appointmentServicesRepository.GetAll().ToList();
            ViewBag.contractServices = appointmentServices.ToList();
            return PartialView("PartialClientHistory", appointments);
        }
        public IActionResult GetAllHistory()
        {
            var appointments = _appointmentsRepository.GetAll().Where(x=>x.StatusContract == 4).ToList();
            if (appointments == null)
                return View();
            var appointmentServices = _appointmentServicesRepository.GetAll().ToList();
            ViewBag.contractServices = appointmentServices.ToList();
            return PartialView("PartialAllHistory", appointments);
        }
    }
}
