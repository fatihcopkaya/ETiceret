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
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productdal;
        public ProductManager(IProductDal productdal)
        {
            _productdal = productdal;
        }

        public async Task<IDataResult<Product>> AddAsync(Product product)
        {
            product.SlugUrl = UrlSeoHelper.UrlSeo(product.SlugUrl);
            await _productdal.AddAsync(product);
            return new SuccessDataResult<Product>(product, Messages.AddMessage);
        }

        public async Task<IResult> AddPhotoAsync(ProductPhoto productPhoto)
        {
            await _productdal.AddPhoto(productPhoto);
            return new SuccessResult(Messages.AddMessage);
        }

        public async Task<IResult> DeleteAsync(Product product)
        {
           await _productdal.UpdateAsync(product);
           return new SuccessResult(Messages.DeleteMessage);
        }

        public async Task<IResult> DeletePhotoAsync(ProductPhoto productPhoto)
        {
            await _productdal.UpdatePhoto(productPhoto);
            return new SuccessResult(Messages.DeleteMessage);
        }

        public async Task<IDataResult<Product>> GetByProductIdAsync(int ProductId)
        {
            var row = await _productdal.GetFirstOrDefaultAsync(x => x.Id == ProductId, x=>x.ProductPhotos);
            if(row != null)
            {
                return new SuccessDataResult<Product>(row);
            }
            return new ErrorDataResult<Product>(new Product(), Messages.RecordMessage);
        }

        public async Task<IResult> GetOrderByProductAsync(Product product)
        {
           await _productdal.UpdateAsync(product);
           return new SuccessResult(Messages.UpdateMessage);
        }

        public async Task<IDataResult<List<Product>>> GetProductListAsync()
        {
            var resultList = await _productdal.GetListAsync(x => x.IsActived == true,
            x=>x.OrderBy(x=>x.OrderBy),
            x=>x.ProductPhotos);
            return new SuccessDataResult<List<Product>>(resultList.ToList());
        }

        public async Task<IResult> UpdateAsync(Product product)
        {
            product.SlugUrl = UrlSeoHelper.UrlSeo(product.SlugUrl);
            await _productdal.UpdateAsync(product);
            return new SuccessResult(Messages.UpdateMessage);
        }

        public async Task<IResult> UpdatePhotoAsync(ProductPhoto productPhoto)
        {
            await _productdal.UpdatePhoto(productPhoto);
            return new SuccessResult(Messages.UpdateMessage);
        }
    }
}