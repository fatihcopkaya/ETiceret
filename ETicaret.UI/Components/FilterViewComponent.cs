using BusiniessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace ETicaret.UI.Components
{
    public class FilterViewComponent : ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public FilterViewComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var row = await _categoryService.GetCategoryListAsync();
            return View(row.Data);
        }
    }
}