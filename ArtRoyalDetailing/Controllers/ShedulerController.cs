using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ArtRoyalDetailing.Database;

namespace ArtRoyalDetailing.Controllers
{
    public class ShedulerController : Controller
    {
        ArdContext _context= new ArdContext();
        [HttpGet]
        public ActionResult Index()
        {
            
            ViewBag.Date = DateTime.Now.Date.ToShortDateString();
            ViewBag.Sheduler = _context.WorkersSheduler.Include(s => s.IdWorkerNavigation).ToList().Where(s => s.DateDay.Value.Year == DateTime.Now.Year && s.DateDay.Value.Day == DateTime.Now.Day && s.DateDay.Value.Month == DateTime.Now.Month).ToList();
            return View();
        }
        /*[HttpPost]
        public ActionResult Index(string day,string month,string year)
        {
            ViewBag.Date = $"{day}.{month}.{year}";
            ViewBag.Sheduler = _context.WorkersShedulers.Include(s=>s.IdWorkerNavigation).ToList().Where(s=>s.DateDay.Value.Year==int.Parse(year)&& s.DateDay.Value.Day == int.Parse(day)&& s.DateDay.Value.Month == int.Parse(month)).ToList();
            return View();
        }*/
        [HttpGet]
        public JsonResult Get(string day, string month, string year)
        {
            return Json(_context.WorkersSheduler.Include(s => s.IdWorkerNavigation).ToList().Where(s => s.DateDay.Value.Year == int.Parse(year) 
                                                  && s.DateDay.Value.Day == int.Parse(day) 
                                                  && s.DateDay.Value.Month == int.Parse(month)).ToList());
        }


        /*// GET: ShedulerController
        

        // GET: ShedulerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ShedulerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ShedulerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ShedulerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ShedulerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ShedulerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ShedulerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }*/
    }
}
