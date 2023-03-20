using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BusiniessLayer.Abstract;
using DataAccessLayer.Concrete.Context;
using EntityLayer.Concrete;
using ETicaret.UI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ETicaret.UI.Controllers
{

    public class OfferController : Controller
    {
        EticaretContext c = new EticaretContext();
        private readonly IProductService _productService;
        private readonly IOfferService _offerService;

        public OfferController(IProductService productService, IOfferService offerService)
        {
            _productService = productService;
            _offerService = offerService;
        }

        [Authorize(Roles = "User")]
        public async Task<IActionResult> Index(OfferVM offerVM)
        {
            var usermail = User.Identity.Name;
            var userId = c.Users.Where(x => x.FirstName == usermail).Select(y => y.Id).FirstOrDefault();
            var offer = await _offerService.GetIdByTaken(userId);
            var list = await _offerService.GetOfferList(userId);
            var productList = await _productService.GetProductListByOffer(offer.Data.ProductId);
            return View(new OfferVM()
            {
                Offers = list.Data,
                Products = productList.Data
            });





        }
        [Authorize(Roles = "User")]
        [HttpPost]
        public async Task<IActionResult> Create(Offer offer, int Id)
        {

            var usermail = User.Identity.Name;
            var userId = c.Users.Where(x => x.FirstName == usermail).Select(y => y.Id).FirstOrDefault();
            var product = await _productService.GetByProductIdAsync(Id);
            try
            {
                var offers = await _offerService.AddAsync(new Offer()
                {
                    OfferPrice = offer.OfferPrice,
                    TakeUserId = product.Data.UserId,
                    UserId = userId,
                    ProductId = product.Data.Id,
                    IsActived = true
                });
                if (offers.Success)
                {
                    TempData["Success"] = offers.Message;
                    return RedirectToAction("Item", "Home", new { Id = product.Data.Id });
                }
            }
            catch (Exception ex)
            {
                TempData["Warning"] = $"Beklenmedik bir hata: {ex.Message}";
            }
            return View();

        }
        [Authorize(Roles = "User")]
        [HttpPost]
        public async Task<IActionResult> Accept(int Id)
        {
            var offer = await _offerService.GetById(Id);
            var product = await _productService.GetByProductIdAsync(offer.Data.ProductId);

            try
            {
                product.Data.Price = offer.Data.OfferPrice;
                product.Data.IsActived = true;
                var update = await _productService.UpdateAsync(product.Data);
                if (update.Success)
                {
                    offer.Data.IsActived = false;
                    await _offerService.DeleteAsync(offer.Data);
                    TempData["Success"] = update.Message;
                    return RedirectToAction("Index", "Offer");
                }
            }
            catch (Exception ex)
            {
                TempData["Warning"] = $"Beklenmedik bir hata: {ex.Message}";
            }
            return View();
        }
    }
}