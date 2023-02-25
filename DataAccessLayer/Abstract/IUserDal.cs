using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreLayer.DataAccess;
using CoreLayer.Utilities.Result;
using EntityLayer.Concrete;

namespace DataAccessLayer.Abstract
{
    public interface IUserDal : IEntityRepositoryAsync<User>
    {
        
    }
}