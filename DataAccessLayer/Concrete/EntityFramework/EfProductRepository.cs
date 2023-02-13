using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreLayer.DataAccess.EntityFramework;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Context;
using EntityLayer.Concrete;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfProductRepository : EfEntityRepositoryBaseAsync<Product, EticaretContext>, IProductDal
    {
        public async Task AddPhoto(ProductPhoto ProductPhoto)
        {
            using var _context = new EticaretContext();
            _context.ProductPhotos.Add(ProductPhoto);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePhoto(ProductPhoto ProductPhoto)
        {
            using var _context = new EticaretContext();
            _context.ProductPhotos.Remove(ProductPhoto);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePhoto(ProductPhoto ProductPhoto)
        {
            using var _context = new EticaretContext();
            _context.ProductPhotos.Update(ProductPhoto);
            await _context.SaveChangesAsync();
        }
    }
}