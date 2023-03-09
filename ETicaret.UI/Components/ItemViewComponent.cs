using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusiniessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace ETicaret.UI.Components
{
    public class ItemViewComponent : ViewComponent
    {
        private readonly IProductService _productService;

        public ItemViewComponent(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int? userId)
        {
            
            
            var result = await _productService.GetProductList();
            
            if(result.Success)
            {
                return View(result.Data);
            }
            return View();
        }
    }
}