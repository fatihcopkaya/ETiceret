using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusiniessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace ETicaret.UI.Components
{
    public class CategoryViewComponent : ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public CategoryViewComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
         public async Task<IViewComponentResult> InvokeAsync()
         {

            var list = await _categoryService.GetCategoryListAsync();
            return View(list.Data);
         }
    }
}