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

    public class CartController : Controller
    {
        
        EticaretContext c = new EticaretContext();
        private readonly IUserService _userService;
        private readonly ICartService _cartService;
        private readonly IProductService _productService;

        public CartController(IUserService userService, ICartService cartService, IProductService productService)
        {
            _userService = userService;
            _cartService = cartService;
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var usermail = User.Identity.Name;
            var UserId = c.Users.Where(x => x.FirstName == usermail).Select(y => y.Id).FirstOrDefault();
            var cart = await _cartService.GetCartIdByUser(UserId);
            var list = await _cartService.GetCartListAsync(UserId);
            var productList = await _productService.GetProductListByCart(cart.Data.ProductId);
            return View(new CartVM()
            {
               Products = productList.Data,
               Carts = list.Data
            });
    

        }
        [HttpPost]
        public async Task<IActionResult> Create(int Id, Cart cart)
        {
            var usermail = User.Identity.Name;
            var UserId = c.Users.Where(x => x.FirstName == usermail).Select(y => y.Id).FirstOrDefault();
            var product = await _productService.GetByProductIdAsync(Id);
            try
            {
                var row = await _cartService.AddAsync(new Cart()
                {
                    UserId = UserId,
                    ProductId = Id,
                    Quantity = cart.Quantity,
                    IsActived = true,
                    Total = cart.Quantity * product.Data.Price,
                    CreatedDate = DateTime.Now
                    
                    
                });
                if (row.Success)
                {
                    TempData["Success"] = row.Message;
                    return RedirectToAction("Index", "Home");
                }

            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Beklenmedik bir hata: {ex.Message}";
            }
            return View();
        }


    }
}