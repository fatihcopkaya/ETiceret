using BusiniessLayer.Abstract;
using BusiniessLayer.Contacts;
using EntityLayer.Concrete;
using ETicaret.UI.Areas.CMS.Models;
using Microsoft.AspNetCore.Mvc;

namespace ETicaret.UI.Areas.CMS.Controllers
{
    [Area("CMS")]
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
        public IActionResult Create(int CategoryId)
        {
            ViewData["CategoryId"] = CategoryId;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CategoryVM categoryVM)
        {
            if (!ModelState.IsValid)
            {
                return View(categoryVM);
            }
            var category = new Category

            {

                Title = categoryVM.Category.Title,
                Description = categoryVM.Category.Description,
                SlugUrl = categoryVM.Category.SlugUrl
            };

            var Category = await _categoryservice.AddAsync(category);

            return RedirectToAction(nameof(CategoryController.Index));


        }
        public async Task<IActionResult> Edit(int? CategoryId)
        {
            if (CategoryId != null)
            {
                var row = await _categoryservice.GetByCategoryIdAsync(CategoryId.Value);
                if (row.Success)
                {
                    return View(new CategoryVM()
                    {
                        Category = row.Data,


                    });
                }

            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(CategoryVM categoryVM)
        {
            if (categoryVM.Category.Id != null)
            {
                try
                {
                    categoryVM.Category.SlugUrl = UrlSeoHelper.UrlSeo(categoryVM.Category.Title);
                    var row = await _categoryservice.UpdateAsync(categoryVM.Category);
                    if (row.Success)
                    {
                        TempData["Succes"] = row.Message;
                    }
                }
                catch (Exception ex)
                {
                    TempData["Error"] = $"Beklenmedik Hata: {ex.Message}";
                }

                if (categoryVM.Category.ParentId != null || categoryVM.Category.ParentId != 0)
                    return RedirectToAction("SubCategory", "Categories", new { id = categoryVM.Category.ParentId });
                return RedirectToAction(nameof(CategoryController.Index));
            }
            return NotFound();

        }

        public async Task<IActionResult> Delete(int? CategoryId)
        {
            if (CategoryId != null)
            {
                var row = await _categoryservice.GetByCategoryIdAsync(CategoryId.Value);
                if (row.Success)
                {
                    row.Data.IsActived = false;
                    await _categoryservice.UpdateAsync(row.Data);
                    TempData["Success"] = Messages.DeleteMessage;
                    if (row.Data.ParentId != null)
                        return RedirectToAction("SubCategory", "Categories", new { id = row.Data.ParentId });
                    return RedirectToAction(nameof(CategoryController.Index));

                }
            }
            return NotFound();
        }
        public async Task<IActionResult> SubCategory(int? Id)
        {
            if (Id != null)
            {
                var categoryList = await _categoryservice.GetCategoryParentList(Id.Value);
                if (categoryList.Success)
                {
                    ViewData["CategoryId"] = Id.Value;
                    return View(categoryList.Data);
                }
                return NotFound();

            }
            return NotFound();
        }

    }



}
