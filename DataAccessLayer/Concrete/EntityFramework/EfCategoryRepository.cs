
using CoreLayer.DataAccess.EntityFramework;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Context;
using EntityLayer.Concrete;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfCategoryRepository : EfEntityRepositoryBaseAsync<Category, EticaretContext>, ICategoryDal
    {
        
    }
}