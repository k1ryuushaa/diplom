using ArtRoyalDetailing.Classes;
using ArtRoyalDetailing.Database.Interfaces;
using ArtRoyalDetailing.Domain.Models;
using ArtRoyalDetailing.Domain.Response;
using ArtRoyalDetailing.Domain.ViewModels;
using ArtRoyalDetatiling.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using ArtRoyalDetailing.Domain.Enum;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ArtRoyalDetailing.Controllers
{
    public class AccountController : Controller
    {

        private readonly IAccountService _accountService;
        private readonly IBaseRepository<Users> _userRepository;

        public AccountController(IAccountService accountService, IBaseRepository<Users> userRepositry)
        {
            _accountService = accountService;
            _userRepository = userRepositry;
        }
        [HttpGet]
        public IActionResult Register() => PartialView("Register");
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            var response = await _accountService.Register(model);
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(response.Data));
                return Json(new BaseResponse<bool>()
                {
                    Description = response.Description,
                    Data = true
                });
            }
            return Json(new BaseResponse<bool>() { 
                Description=response.Description,
                Data=false
            });
        }
        [HttpPost]
        public async Task<IActionResult> RegisterConfirm(string login, string phone, string email, string name)
        {
            var user = _userRepository.GetAll().FirstOrDefault(x => x.UserLogin == login||x.UserPhonenumber.Equals(phone));
            if(user!=null)
            {
                return Json(new BaseResponse<bool>()
                {
                    Data=false,
                    Description="Пользователь с таким логином или номером телефона уже существует"
                });
            }
            user = _userRepository.GetAll().FirstOrDefault(x => x.UserEmail.Equals(email));
            if (user != null)
            {
                return Json(new BaseResponse<bool>()
                {
                    Data = false,
                    Description = "Почта уже используется"
                });
            }
            if(!EmailSender.IsValidEmail(email))
            {
                return Json(new BaseResponse<bool>()
                {
                    Data = false,
                    Description = "Неверная почта"
                });
            }
            try
            {
                var code = EmailSender.GenerateCode();
                EmailSender.SendMessageRegistration(email, code, name);
                return Json(new BaseResponse<bool>()
                {
                    Data = true,
                    Description = code
                });
            }
            catch(Exception ex)
            {
                return Json(new BaseResponse<bool>()
                {
                    Data = false,
                    Description = "Ошибка сервера, повторите попытку позже"
                });
            }
        }

        [HttpGet]
        public IActionResult Login() => PartialView("Login");

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {

            var response = await _accountService.Login(model);
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(response.Data));
                return Json(new BaseResponse<bool>()
                {
                    Description = response.Description,
                    Data = true
                });
            }
            return Json(new BaseResponse<bool>()
            {
                Description = response.Description,
                Data = false
            });
        }
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var response = await _accountService.ChangePassword(model);
                if (response.StatusCode == Domain.Enum.StatusCode.OK)
                {
                    return Json(new { description = response.Description });
                }
            }
            var modelError = ModelState.Values.SelectMany(v => v.Errors);

            return StatusCode(StatusCodes.Status500InternalServerError, new { modelError.FirstOrDefault().ErrorMessage });
        }
    }
}
