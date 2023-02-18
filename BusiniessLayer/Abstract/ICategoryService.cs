using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreLayer.Utilities.Result;
using EntityLayer.Concrete;

namespace BusiniessLayer.Abstract
{
    public interface ICategoryService
    {
        Task<IDataResult<Category>> GetByCategoryIdAsync(int CategoryId);
        Task<IDataResult<List<Category>>> GetCategoryListAsync();
        Task<IDataResult<List<Category>>> GetCategoryParentList(int CategoryId);
        Task<IDataResult<Category>> AddAsync(Category category);
        Task<IResult> UpdateAsync(Category category);
        Task<IResult> DeleteAsync(Category category);
         Task<IResult> GetOrderByCategoryAsync(Category category);

    }
}