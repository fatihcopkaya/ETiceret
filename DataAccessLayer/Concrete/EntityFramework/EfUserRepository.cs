using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreLayer.DataAccess.EntityFramework;
using CoreLayer.Utilities.Result;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Context;
using EntityLayer.Concrete;
using System.Security.Claims;


namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfUserRepository : EfEntityRepositoryBaseAsync<User, EticaretContext>, IUserDal
    {
       
    }
}