using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusiniessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace ETicaret.UI.Components
{
    public class UsersProductViewComponent : ViewComponent
    {
        private readonly IProductService _productService;
        private readonly IUserService _userService;

        public UsersProductViewComponent(IProductService productService, IUserService userService)
        {
            _productService = productService;
            _userService = userService;
        }
        public async Task<IViewComponentResult> InvokeAsync(int Id)
        {
            var list = await _productService.GetProductListByUserAsync(Id);
             return View(list.Data);
        }
    }
}