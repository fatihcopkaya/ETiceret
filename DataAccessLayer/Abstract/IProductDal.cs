using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreLayer.DataAccess;
using EntityLayer.Concrete;

namespace DataAccessLayer.Abstract
{
    public interface IProductDal : IEntityRepositoryAsync<Product>
    {
        Task AddPhoto(ProductPhoto ProductPhoto);
        Task UpdatePhoto(ProductPhoto ProductPhoto);
        Task DeletePhoto(ProductPhoto ProductPhoto);
    }
}