using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreLayer.Utilities.Result;
using EntityLayer.Concrete;

namespace BusiniessLayer.Abstract
{
    public interface ICartService
    {
        Task<IDataResult<Cart>> AddAsync(Cart cart);
        Task<IDataResult<List<Cart>>> GetCartListAsync(int Id);
        Task<IResult> UpdateAsync(Cart cart);
        Task<IResult> DeleteAsync(Cart cart);
        Task<IDataResult<Cart>> GetCartIdByUser(int Id);
        Task<IDataResult<List<Cart>>> GetCartListByOrderAsync(int Id);
        


    }
}