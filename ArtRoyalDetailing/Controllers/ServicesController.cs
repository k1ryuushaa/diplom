using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArtRoyalDetailing.Database;
using ArtRoyalDetailing.Domain;
using ArtRoyalDetailing.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore;

namespace ArtRoyalDetailing.Controllers
{
    public class ServicesController : Controller
    {
        private readonly ArdContext _context;

        public ServicesController(ArdContext context)
        {
            _context = context;
        }

        // GET: Services
        public async Task<IActionResult> Index()
        {
            var ardContext = _context.Services.Include(s => s.ServiceTypeNavigation);
            ViewBag.ServiceTypes = _context.ServiceType.ToList();
            ViewBag.ServiceCosts = _context.ServicesCosts.ToList();
            return View(await ardContext.ToListAsync());
        }
    }
}
