using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusiniessLayer.Abstract;
using BusiniessLayer.Contacts;
using CoreLayer.Utilities.Result;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusiniessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public async Task<IDataResult<Category>> AddAsync(Category category)
        {
           category.SlugUrl = UrlSeoHelper.UrlSeo(category.SlugUrl);
           await _categoryDal.AddAsync(category);
           return new SuccessDataResult<Category>(category, Messages.AddMessage);
        }

        public async Task<IResult> DeleteAsync(Category category)
        {
           await _categoryDal.UpdateAsync(category);
           return new SuccessDataResult<Category>(Messages.DeleteMessage);
        }

        public async Task<IDataResult<Category>> GetByCategoryIdAsync(int CategoryId)
        {
            var result = await _categoryDal.GetFirstOrDefaultAsync(x => x.Id == CategoryId, x => x.Parent);
            return result != null ? new SuccessDataResult<Category>(result) : new ErrorDataResult<Category>(Messages.RecordMessage);
            
        }

        public async Task<IDataResult<List<Category>>> GetCategoryListAsync()
        {
            var resultList = await _categoryDal.GetListAsync(x => x.IsActived == true && x.Parent == null, 
            x => x.OrderBy(x => x.OrderBy),
            x => x.Children);
            return new SuccessDataResult<List<Category>>(resultList.ToList());
        }

        public async Task<IDataResult<List<Category>>> GetCategoryParentList(int CategoryId)
        {
            var resultList = await _categoryDal.GetListAsync(x => x.IsActived == true && x.ParentId == CategoryId,
            x => x.OrderBy(x => x.OrderBy),
            x => x.Parent);
            return new SuccessDataResult<List<Category>>(resultList.ToList());
        }

        public async Task<IResult> GetOrderByCategoryAsync(Category category)
        {
            await _categoryDal.UpdateAsync(category);
            return new SuccessResult(Messages.UpdateMessage);
        }

        public async Task<IResult> UpdateAsync(Category category)
        {
            category.SlugUrl = UrlSeoHelper.UrlSeo(category.SlugUrl);
            await _categoryDal.UpdateAsync(category);
            return new SuccessResult(Messages.UpdateMessage);
        }
    }
}