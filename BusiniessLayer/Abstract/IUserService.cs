using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreLayer.Utilities.Result;
using EntityLayer.Concrete;

namespace BusiniessLayer.Abstract
{
    public interface IUserService
    {
        Task<IDataResult<User>> SignInAsync(User user);
        Task<IDataResult<List<User>>> GetListListAsync();
        Task<IDataResult<User>> GetByIdAsync(int userId);
        Task<IDataResult<User>> GetByMailAsync(string userEmail);
        Task<IDataResult<User>> GetByUserTokenAsync(string token);
        Task<IDataResult<User>> AddAsync(User user);
        Task<IResult> UpdateAsync(User user);
        Task<IResult> DeleteAsync(User user);
    }
}