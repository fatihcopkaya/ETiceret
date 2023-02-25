using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BusiniessLayer.Abstract;
using BusiniessLayer.Contacts;
using CoreLayer.Utilities.Result;
using DataAccessLayer.Concrete.Context;
using EntityLayer.Concrete;
using ETicaret.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ETicaret.UI.Controllers
{

    public class ProductController : Controller
    {
        EticaretContext c = new EticaretContext();
        private readonly IProductService _productService;
        private readonly IDocumentService _documentService;
        private readonly ICategoryService _categoryService;


        public ProductController(IProductService productService, IDocumentService documentService, ICategoryService categoryService)
        {

            _productService = productService;
            _documentService = documentService;
            _categoryService = categoryService;

        }

        public async Task<IActionResult> Index()
        {
            var usermail = User.Identity.Name;
            var UserId = c.Users.Where(x => x.FirstName == usermail).Select(y => y.Id).FirstOrDefault();
            var result = await _productService.GetProductListByUserAsync(UserId);
            if (result.Success)
            {
                return View(result.Data);
            }
            return View();
        }
        public async Task<IActionResult> Category()
        {
            var list = await _categoryService.GetCategoryListAsync();
            return View(list.Data);

        }
        public async Task<IActionResult> SubCategory(int? Id)
        {
            if (Id > 0)
            {
                var subcategory = await _categoryService.GetCategoryParentList(Id.Value);
                if (subcategory.Success)
                {
                    ViewData["CategoryId"] = Id.Value;
                    await _categoryService.GetByCategoryIdAsync(Id.Value);
                    return View(subcategory.Data);
                }
                return NotFound();
            }
            return NotFound();
        }


        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(int? Id, ProductVM productVM, IFormFile file)
        {
            var usermail = User.Identity.Name;
            var UserId = c.Users.Where(x => x.FirstName == usermail).Select(y => y.Id).FirstOrDefault();
            productVM.Product.UserId = UserId;


            try
            {
                var FileCode = await _documentService.AddUploadAsync(file, "/file/product/");
                if (!FileCode.Success)
                {
                    TempData["Warning"] = FileCode.Message;
                }
                else
                {
                    var product = await _productService.AddAsync(new Product()
                    {
                        IsActived = true,
                        Title = productVM.Product.Title,
                        Description = productVM.Product.Description,
                        FileCode = FileCode.Data,
                        CategoryId = Id.Value,
                        SlugUrl = UrlSeoHelper.UrlSeo(productVM.Product.Title),
                        UserId = productVM.Product.UserId,
                    });
                    if (product.Success)
                    {
                        await _productService.AddPhotoAsync(new ProductPhoto()
                        {
                            FileCode = FileCode.Data,
                            ProductId = product.Data.Id,
                            IsActived = true

                        });
                    }

                    TempData["Success"] = product.Message;
                    return RedirectToAction("Index", "Home");
                }


            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Beklenmedik bir hata: {ex.Message}";
            }
            return View(productVM);
        }
        public async Task<IActionResult> Edit(int? Id)
        {
            if (Id != null)
            {
                var result = await _productService.GetByProductIdAsync(Id.Value);
                if (result.Success)
                {
                    var category = await _categoryService.GetByCategoryIdAsync(result.Data.CategoryId);

                    return View(new ProductVM
                    {

                        Product = result.Data,
                        Categories = (await _categoryService.GetCategoryParentList(category.Data.ParentId.Value)).Data.ToList()
                    }
                    );
                }
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int? Id, ProductVM productVM, IFormFile file)
        {
            var usermail = User.Identity.Name;
            var UserId = c.Users.Where(x => x.FirstName == usermail).Select(y => y.Id).FirstOrDefault();
            productVM.Product.UserId = UserId;


            try
            {
                if (file != null)
                {
                    if (productVM.Product.FileCode != null || productVM.Product.FileCode != string.Empty)
                    {
                        IDataResult<string> FileCode = await _documentService.UpdateUploadAsync(file, productVM.Product.FileCode, "/file/product/");
                        productVM.Product.FileCode = FileCode.Data;
                        if (!FileCode.Success)
                        {
                            TempData["Warning"] = FileCode.Message;
                            return View(productVM);
                        }
                    }
                }
                productVM.Product.SlugUrl = UrlSeoHelper.UrlSeo(productVM.Product.Title);
                productVM.Product.Id = Id.Value;
                productVM.Product.IsActived = true;
                var update = await _productService.UpdateAsync(productVM.Product);
                if (update.Success)
                {
                    TempData["Success"] = update.Message;
                    return RedirectToAction(nameof(ProductController.Index));
                }
            }
            catch (Exception ex)
            {
                TempData["Warning"] = $"Beklenmedik bir hata: {ex.Message}";
            }
            return NotFound();
        }


    }
}