using ArtRoyalDetailing.Database.Interfaces;
using ArtRoyalDetailing.Domain.Enum;
using ArtRoyalDetailing.Domain.Models;
using ArtRoyalDetatiling.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtRoyalDetailing.Controllers
{
    public class LKController : Controller
    {

        private readonly IBaseRepository<Users> _userRepository;
        private readonly IBaseRepository<Roles> _rolesRepository;
        private readonly IBaseRepository<Domain.Models.Services> _servicesRepository;
        private readonly IBaseRepository<Contracts> _appointmentsRepository;
        private readonly IBaseRepository<Salary> _salaryRepository;
        private readonly IBaseRepository<ContractsServices> _appointmentServicesRepository;
        private readonly IWorkerService _workerService;
        private readonly IUserService _userService;
        public LKController(IBaseRepository<Domain.Models.Services> servicesRepository,
                            IBaseRepository<Users> userRepository,
                            IBaseRepository<Salary> salaryRepository,
                            IBaseRepository<Contracts> appointmentsRepository,
                            IBaseRepository<ContractsServices> appointmentServicesRepository,
                            IWorkerService workerService,
                            IBaseRepository<Roles> rolesRepository,
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
        }
        public IActionResult Index()
        {
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
            var response = await _workerService.SetSalary(workerId);
            return Json(response);
        }
        public async Task<IActionResult> RemoveWorker(int workerId)
        {
            var response = await _userService.DeleteUser(workerId);
            return Json(response);
        }
    }
}
