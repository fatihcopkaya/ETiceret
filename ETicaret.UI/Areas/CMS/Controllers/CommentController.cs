using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BusiniessLayer.Abstract;
using ETicaret.UI.Areas.Cms.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ETicaret.UI.Areas.Cms.Controllers
{
    [Area("Cms")]
    [Authorize(Roles = "Admin")]
    public class CommentController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICommentService _commentService;

        public CommentController(IProductService productService, ICommentService commentService)
        {
            _productService = productService;
            _commentService = commentService;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _commentService.GetCommentList();
            var productList = await _productService.GetProductListByCommet();

            return View(new CommentVM()
            {
                Comments = list.Data,
                Products = productList.Data
            });
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int Id)
        {
             var row = await _commentService.GetByCommentIdAsync(Id);
             if(row.Success)
             {
                row.Data.IsActived = false;
                await _commentService.DeleteAsync(row.Data);
                return RedirectToAction(nameof(CommentController.Index));
             }
             return NotFound();
        }

        
    }
}