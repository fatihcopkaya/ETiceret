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
    public class EfProductPhotoRepository : EfEntityRepositoryBaseAsync<ProductPhoto, EticaretContext>, IProductPhotoDal
    {
        
    }
}