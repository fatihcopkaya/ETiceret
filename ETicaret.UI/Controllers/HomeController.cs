using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ETicaret.UI.Models;
using BusiniessLayer.Abstract;

namespace ETicaret.UI.Controllers;

public class HomeController : Controller
{
    private readonly IProductService _productService;

    public HomeController(IProductService productService)
    {
        _productService = productService;
    }

    public async Task<IActionResult> Index()
    {
       var list = await _productService.GetProductList();
       return View(list.Data);
    }
    public async Task<PartialViewResult> SliderPartial()
    {
        var result = await _productService.GetProductList();
        return PartialView(result);
    }
    public async Task<IActionResult> Item(int? Id)
    {
        var item = await _productService.GetByProductIdAsync(Id.Value);
        return View(item);
    }

  

}
