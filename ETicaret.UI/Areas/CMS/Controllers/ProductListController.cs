using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BusiniessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ETicaret.UI.Areas.Cms.Controllers
{
    [Area("Cms")]
    [Authorize(Roles = "Admin")]
    public class ProductListController : Controller
    {
        private readonly IProductService _productService;

        public ProductListController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _productService.GetProductList();
            return View(list.Data);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int Id)
        {
            var row = await _productService.GetByProductIdAsync(Id);
            row.Data.IsActived = false;
            await _productService.DeleteAsync(row.Data);
            return RedirectToAction(nameof(ProductListController.Index));
        }


    }
}