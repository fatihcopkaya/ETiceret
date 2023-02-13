using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreLayer.Utilities.Result;
using EntityLayer.Concrete;

namespace BusiniessLayer.Abstract
{
    public interface IProductService
    {
        Task<IDataResult<Product>> GetByProductIdAsync(int ProductId);
        Task<IDataResult<List<Product>>> GetProductListAsync();
        Task<IResult> GetOrderByProductAsync(Product product);
        Task<IDataResult<Product>> AddAsync(Product product);
        Task<IResult> UpdateAsync(Product product);
        Task<IResult> DeleteAsync(Product product);
        Task<IResult> AddPhotoAsync(ProductPhoto productPhoto);
        Task<IResult> UpdatePhotoAsync(ProductPhoto productPhoto);
        Task<IResult> DeletePhotoAsync(ProductPhoto productPhoto);

    }
}