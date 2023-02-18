using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BusiniessLayer.Abstract;
using BusiniessLayer.Contacts;
using EntityLayer.Concrete;
using ETicaret.UI.Areas.Cms.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ETicaret.UI.Areas.Cms.Controllers
{
    [Area("Cms")]
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryservice;

        public CategoryController(ICategoryService categoryservice)
        {
            _categoryservice = categoryservice;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _categoryservice.GetCategoryListAsync();
            if (list.Success)
            {
                return View(list.Data);
            }
            return NotFound();
        }
        public async Task<IActionResult> Create(int? CategoryId)
        {

            TempData["CategoryId"] = CategoryId;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(int? CategoryId,CategoryVM categoryVM)
        {
            try
            {
                if(CategoryId != null)
                {
                    categoryVM.Category.ParentId = CategoryId;
                }

                var errors = ModelState.SelectMany(x => x.Value.Errors.Select(z => z.ErrorMessage));
                var result = await _categoryservice.AddAsync(new Category()
                {
                    IsActived = true,
                    SlugUrl = UrlSeoHelper.UrlSeo(categoryVM.Category.Title),
                    Description = categoryVM.Category.Description,
                    Title = categoryVM.Category.Title,
                    ParentId = categoryVM.Category.ParentId
                });
                TempData["Success"] = result.Message;
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Beklenmedik Hata: {ex.Message}";
            }
            if (categoryVM.Category.ParentId != null && categoryVM.Category.ParentId != 0)
                return RedirectToAction("SubCategory", "Category", new { id = categoryVM.Category.ParentId });
            return RedirectToAction(nameof(CategoryController.Index));
        }
        // public async Task<IActionResult> CreateSub(int? CategoryId)
        // {
        //     TempData["CategoryId"] = CategoryId;
        //     return View();
        // }
        // [HttpPost]
        // public async Task<IActionResult> CreateSub(int? CategoryId, CategoryVM categoryVM)
        // {

        //     try
        //     {
        //         var errors = ModelState.SelectMany(x => x.Value.Errors.Select(z => z.ErrorMessage));
        //         var result = await _categoryservice.AddAsync(new Category()
        //         {
        //             IsActived = true,
        //             SlugUrl = UrlSeoHelper.UrlSeo(categoryVM.Category.Title),
        //             Description = categoryVM.Category.Description,
        //             Title = categoryVM.Category.Title,
        //             ParentId = CategoryId
        //         });

        //         TempData["Success"] = result.Message;
        //     }
        //     catch (Exception ex)
        //     {
        //         TempData["Error"] = $"Beklenmedik Hata: {ex.Message}";
        //     }
        //     if (categoryVM.Category.ParentId != null && categoryVM.Category.ParentId != 0)
        //         return RedirectToAction("SubCategory", "Categories", new { id = categoryVM.Category.ParentId });
        //     return RedirectToAction(nameof(CategoryController.Index));

        // }
        public async Task<IActionResult> Delete(int id)
        {
            var row = await _categoryservice.GetByCategoryIdAsync(id);
            if (row.Success)
            {
                row.Data.IsActived = false;
                await _categoryservice.UpdateAsync(row.Data);
                TempData["Succes"] = Messages.DeleteMessage;
            }
            if (row.Data.ParentId != null)
                return RedirectToAction("SubCategory", "Categories", new { id = row.Data.ParentId });
            return RedirectToAction(nameof(CategoryController.Index));
        }
        public async Task<IActionResult> Edit(int? Id, int? ParentId)
        {
            if (Id != null)
            {

                var row = await _categoryservice.GetByCategoryIdAsync(Id.Value);
                if (row.Success)
                {
                    return View(new CategoryVM()
                    {
                        Category = row.Data
                    });

                }

            }
            return NotFound();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? ParentId, int? Id, CategoryVM categoryVM)
        {

            if (categoryVM.Category.Id > 0)
            {
                try
                {
                    var row = await _categoryservice.GetByCategoryIdAsync(Id.Value);
                    ParentId = row.Data.ParentId;
                    categoryVM.Category.ParentId = ParentId;
                    categoryVM.Category.SlugUrl = UrlSeoHelper.UrlSeo(categoryVM.Category.Title);
                    categoryVM.Category.IsActived = true;
                    var result = await _categoryservice.UpdateAsync(categoryVM.Category);
                    if (result.Success)
                    {

                        TempData["Success"] = Messages.UpdateMessage;
                    }
                }
                catch (Exception ex)
                {
                    TempData["Error"] = $"Beklenmedik Hata: {ex.Message}";
                }
                if (categoryVM.Category.ParentId != null)
                { return RedirectToAction("SubCategory", "Category", new { id = categoryVM.Category.ParentId }); }
                else
                {
                    return RedirectToAction(nameof(CategoryController.Index));
                }

            }
            return NotFound();

        }
        [HttpPost]
        public async Task<IActionResult> Order(List<Order> orders)
        {
            try
            {
                foreach (var item in orders)
                {
                    var category = await _categoryservice.GetByCategoryIdAsync(item.Id);
                    if (category == null)
                    {
                        continue;
                    }
                    category.Data.OrderBy = item.Place;
                    await _categoryservice.GetOrderByCategoryAsync(category.Data);
                }
                return Ok(new
                {
                    Status = 200,
                    Message = Messages.UpdateMessage
                });
            }
            catch (Exception ex)
            {
                return Ok(new
                {
                    Status = 404,
                    ex.Message
                });
            }
        }
        public async Task<IActionResult> SubCategory(int? Id)
        {
            if (Id != null)
            {
                var categoryList = await _categoryservice.GetCategoryParentList(Id.Value);

                if (categoryList.Success)
                {
                    ViewData["CategoryId"] = Id.Value;
                    await _categoryservice.GetByCategoryIdAsync(Id.Value);
                    return View(categoryList.Data);
                }
                return NotFound();
            }
            return NotFound();
        }


    }
}