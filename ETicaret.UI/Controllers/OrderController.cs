using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BusiniessLayer.Abstract;
using DataAccessLayer.Concrete.Context;
using EntityLayer.Concrete;
using ETicaret.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ETicaret.UI.Controllers
{

    public class OrderController : Controller
    {
        EticaretContext c = new EticaretContext();
        private readonly IProductService _productService;
        private readonly IAdressService _adressService;
        private readonly ICartService _cartService;
        private readonly IOrderService _orderService;

        public OrderController(IProductService productService, IAdressService adressService, ICartService cartService, IOrderService orderService)
        {
            _productService = productService;
            _adressService = adressService;
            _cartService = cartService;
            _orderService = orderService;
        }

        public async Task<IActionResult> Index()
        {
            var usermail = User.Identity.Name;
            var userId = c.Users.Where(x => x.FirstName == usermail).Select(y => y.Id).FirstOrDefault();
            var products = await _productService.GetProductListByOrder(userId);
            var adresses = await _adressService.GetAdressListByOrder(userId);
            var carts = await _cartService.GetCartListByOrderAsync(userId);
            return View(new OrderVM()
            {
                Products = products.Data,
                Carts = carts.Data,
                Adresses = adresses.Data

            });
        }
        public async Task<IActionResult> Create()
        {
            var usermail = User.Identity.Name;
            var userId = c.Users.Where(x => x.FirstName == usermail).Select(y => y.Id).FirstOrDefault();
            var cart = await _cartService.GetCartIdByUser(userId);
            var products = await _productService.GetProductListByCart(userId);
            var adresses = await _adressService.GetAdressListByUser(userId);
            var carts = await _cartService.GetCartListAsync(userId);
            return View(new OrderVM()
            {
                Products = products.Data,
                Carts = carts.Data,
                Adresses = adresses.Data
            });
        }
        [HttpPost]
        public async Task<IActionResult> Create(int Id)
        {
            var usermail = User.Identity.Name;
            var userId = c.Users.Where(x => x.FirstName == usermail).Select(y => y.Id).FirstOrDefault();
            var data = await _cartService.GetCartListAsync(userId);
            try
            {
                foreach (var item in data.Data)
                {
                    var add = await _orderService.AddAsync(new Order()
                    {
                        AdressId = Id,
                        UserId = userId,
                        ProductId = item.ProductId,
                        CartId = item.Id,
                        CreateDate = DateTime.Now,
                        IsActived = true

                    });
                    TempData["Success"] = add.Message;

                }



                return RedirectToAction("Index", "Order");


            }
            catch (Exception ex)
            {
                TempData["Warning"] = $"Beklenmedik bir hata: {ex.Message}";
            }
            return NotFound();
        }


    }
}