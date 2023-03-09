using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ETicaret.UI.Models;
using BusiniessLayer.Abstract;
using DataAccessLayer.Concrete.Context;
using EntityLayer.Concrete;
using BusiniessLayer.Contacts;

namespace ETicaret.UI.Controllers;

public class HomeController : Controller
{

    EticaretContext c = new EticaretContext();
    private readonly IProductService _productService;
    private readonly ICommentService _commentService;
    private readonly IUserService _userService;
    private readonly ICartService _cartService;

    public HomeController(IProductService productService, ICommentService commentService, IUserService userService, ICartService cartService)
    {
        _productService = productService;
        _commentService = commentService;
        _userService = userService;
        _cartService = cartService;
    }

    public async Task<IActionResult> Index(string search)
    {
        var list = await _productService.GetProductList();
        if (!string.IsNullOrEmpty(search))
        {
            list = await _productService.GetProductListBySearch(search);
        }
        return View(list.Data);
    }
    public async Task<PartialViewResult> SliderPartial()
    {
        var result = await _productService.GetProductList();
        return PartialView(result);
    }
    public async Task<IActionResult> Item(int? Id)
    {
        ViewBag.i = Id;
        var item = await _productService.GetByProductIdAsync(Id.Value);
        var user = await _userService.GetByIdAsync(item.Data.UserId);

        return View(new ProductVM()
        {
            Product = item.Data,
            ProductPhoto = item.Data.ProductPhoto,
            User = user.Data
        });
    }

    [HttpPost]
    public async Task<IActionResult> Item(Comment comment, int? Id) // add comment method
    {
        var usermail = User.Identity.Name;
        var userId = c.Users.Where(x => x.FirstName == usermail).Select(y => y.Id).FirstOrDefault();
        try
        {
            var userinfo = await _userService.GetByIdAsync(userId);
            var result = await _commentService.AddAsync(new Comment()
            {
                Content = comment.Content,
                ProductId = Id.Value,
                UserId = userId,
                IsActived = true,
                CreatedTime = DateTime.Now,
                CommentUsername = userinfo.Data.FirstName
            });
            return RedirectToAction("Item", "Home");
        }
        catch (Exception ex)
        {
            TempData["Error"] = $"Beklenmedik bir hata: {ex.Message}";
        }
        return View();

    }

    [HttpPost]
    public async Task<IActionResult> DeleteComment(int Id)
    {
        var row = await _commentService.GetByCommentIdAsync(Id);

        if (row.Success)
        {
            row.Data.IsActived = false;
            await _commentService.DeleteAsync(row.Data);
            TempData["Success"] = Messages.DeleteMessage;
        }
        var product = await _productService.GetByProductIdAsync(row.Data.ProductId);

        return RedirectToAction("Item", new { Id = product.Data.Id });
    }




}
