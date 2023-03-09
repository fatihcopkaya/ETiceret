using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BusiniessLayer.Abstract;
using DataAccessLayer.Concrete.Context;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;


namespace ETicaret.UI.Controllers
{

    public class AdressController : Controller
    {
        EticaretContext c = new EticaretContext();
        private readonly IUserService _userService;
        private readonly IAdressService _adressService;

        public AdressController(IUserService userService, IAdressService adressService)
        {
            _userService = userService;
            _adressService = adressService;
        }

        public async Task<IActionResult> Index()
        {
            var usermail = User.Identity.Name;
            var userId = c.Users.Where(x => x.FirstName == usermail).Select(y => y.Id).FirstOrDefault();
            var list = await _adressService.GetAdressList(userId);
            return View(list.Data);
        }
        public async Task<IActionResult> Create()
        {
            var usermail = User.Identity.Name;
            var userId = c.Users.Where(x => x.FirstName == usermail).Select(y => y.Id).FirstOrDefault();
            var userResult = await _userService.GetByIdAsync(userId);
            return View(new Adress()
            {
                User = userResult.Data,

            });

        }
        [HttpPost]
        public async Task<IActionResult> Create(Adress adress)
        {
            var usermail = User.Identity.Name;
            var userId = c.Users.Where(x => x.FirstName == usermail).Select(y => y.Id).FirstOrDefault();
            try
            {
                var row = await _adressService.AddAsync(new Adress()
                {
                    UserId = userId,
                    FirstName = adress.FirstName,
                    LastName = adress.LastName,
                    City = adress.City,
                    Zip = adress.Zip,
                    AdressDetail = adress.AdressDetail,
                    Title = adress.Title,
                    IsActived = true
                });
                if (row.Success)
                {
                    TempData["Success"] = row.Message;
                    return RedirectToAction("Index", "Cart");
                }

            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Beklenmedik bir hata: {ex.Message}";
            }
            return View();

        }
        public async Task<IActionResult> Edit(int Id)
        {
            var usermail = User.Identity.Name;
            var userId = c.Users.Where(x => x.FirstName == usermail).Select(y => y.Id).FirstOrDefault();
            var row = await _adressService.GetById(Id, userId);
            if (row.Success)
            {
                return View(row.Data);

            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int Id, Adress adress)
        {
            var usermail = User.Identity.Name;
            var userId = c.Users.Where(x => x.FirstName == usermail).Select(y => y.Id).FirstOrDefault();
            try
            {
                adress.UserId = userId;
                adress.IsActived = true;
                adress.Id = Id;
                var update = await _adressService.UpdateAsync(adress);
                if (update.Success)
                {
                    TempData["Success"] = update.Message;
                    return RedirectToAction("Index", "Adress");
                }
            }
            catch (Exception ex)
            {
                TempData["Warning"] = $"Beklenmedik bir hata: {ex.Message}";
            }
            return NotFound();


        }
        [HttpPost]
        public async Task<IActionResult> Delete(int Id)
        {
            var usermail = User.Identity.Name;
            var userId = c.Users.Where(x => x.FirstName == usermail).Select(y => y.Id).FirstOrDefault();
            var row = await _adressService.GetById(Id, userId);
            if (row.Success)
            {
                try
                {
                    row.Data.IsActived = false;
                    var delete = await _adressService.DeleteAsync(row.Data);
                    if (delete.Success)
                    {
                        TempData["Success"] = delete.Message;
                        return RedirectToAction("Index", "Adress");
                    }

                }
                catch(Exception ex)
                {
                    TempData["Warning"] = $"Beklenmedik bir hata: {ex.Message}";
                }
                 return NotFound();
               
            }
             return NotFound();

        }



    }
}