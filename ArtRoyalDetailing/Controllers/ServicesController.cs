using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArtRoyalDetailing.Database;
using ArtRoyalDetailing.Domain;
using ArtRoyalDetailing.Domain.Models;
using ArtRoyalDetailing.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore;

namespace ArtRoyalDetailing.Controllers
{
    public class ServicesController : Controller
    {
        private readonly ArdContext _context;
        private readonly IArdServicesService _servicesService;

        public ServicesController(ArdContext context, IArdServicesService servicesService)
        {
            _context = context;
            _servicesService = servicesService;
        }

        public async Task<IActionResult> Index()
        {
            var ardContext = _context.Services.Include(s => s.ServiceTypeNavigation);
            ViewBag.ServiceTypes = _context.ServiceType.ToList();
            ViewBag.ServiceCosts = _context.ServicesCosts.ToList();
            return View(await ardContext.ToListAsync());
        }
        public async Task<IActionResult> RenameService(int serviceId, string newName)
        {
            var response = await _servicesService.RenameService(serviceId, newName);
            return Json(response);
        }
        public async Task<IActionResult> ChangeCost(int serviceId,string classAuto,string cost)
        {
            var response = await _servicesService.ChangeCost(serviceId,classAuto,cost);
            return Json(response);
        }
        public async Task<IActionResult> RemoveService(int serviceId)
        {
            var response = await _servicesService.RemoveService(serviceId);
            return Json(response);
        }
    }
}
