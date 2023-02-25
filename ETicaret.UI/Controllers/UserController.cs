using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BusiniessLayer.Abstract;
using CoreLayer.Utilities.Security.Hashing;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Context;
using EntityLayer.Concrete;
using ETicaret.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ETicaret.UI.Controllers
{

    public class UserController : Controller
    {
        EticaretContext c = new EticaretContext();

        private readonly IUserService _userService;

        public UserController(IUserDal userDal, IUserService userService)
        {

            _userService = userService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(User user, string returnUrl)
        {

            var users = await _userService.SignInAsync(user);
            if (!users.Success)
            {
                TempData["Error"] = users.Message;
                return View(user);
            }
            TempData["Success"] = users.Message;
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");

        }
        public async Task<IActionResult> Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(User user)
        {

            await _userService.Register(user);


            return RedirectToAction(nameof(UserController.Login));
        }
        public async Task<IActionResult> AccountDetail()
        {
            var usermail = User.Identity.Name;
            var UserId = c.Users.Where(x => x.FirstName == usermail).Select(y => y.Id).FirstOrDefault();
            var row = await _userService.GetByIdAsync(UserId);
            if (row.Success)
            {

                return View(row.Data);


            }


            return NotFound();

        }
        [HttpPost]
        public async Task<IActionResult> AccountDetail(User user)
        {
            var usermail = User.Identity.Name;
            var UserId = c.Users.Where(x => x.FirstName == usermail).Select(y => y.Id).FirstOrDefault();
            user.Id = UserId;
            if (user.Id > 0)
            {
                try
                {

                   
                    user.IsActived = true;
                    var row = await _userService.UpdateAsync(user);
                    await _userService.SignInAsync(user);


                    if (row.Success)
                    {
                        return RedirectToAction("AccountDetail", "User");
                    }

                }
                catch (Exception ex)
                {
                    TempData["Error"] = $"Beklenmedik Hata: {ex.Message}";
                }
            }
            return RedirectToAction("Index", "Home");

        }

    }
}