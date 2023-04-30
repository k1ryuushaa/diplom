using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ArtRoyalDetailing.Database;
using ArtRoyalDetatiling.Services.Interfaces;
using ArtRoyalDetatiling.Services.Implementations;
using ArtRoyalDetailing.Database.Repositories;
using ArtRoyalDetailing.Domain.Enum;

namespace ArtRoyalDetailing.Controllers
{
    public class ShedulerController : Controller
    {
        private readonly IWorkersShedulerService _shedulerService;
        public ShedulerController(IWorkersShedulerService shedulerService)
        {
            _shedulerService = shedulerService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<JsonResult> Get(string day, string month, string year)
        {
            return Json(await _shedulerService.GetSheduler(day,month,year));
        }
        [HttpGet]
        public async Task<JsonResult> Set(int workerId, string date, string time)
        {
            return Json(await _shedulerService.CreateEnroll(workerId, date, time));
        }
    }
}
