using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreLayer.Utilities.Result;
using EntityLayer.Concrete;

namespace BusiniessLayer.Abstract
{
    public interface IAdressService
    {
        Task<IDataResult<Adress>> AddAsync(Adress adress);
        Task<IDataResult<List<Adress>>> GetAdressListByUser(int Id);
         Task<IDataResult<List<Adress>>> GetAdressListByOrder(int Id);
        Task<IDataResult<Adress>> GetById(int Id, int UserId);

        Task<IResult> UpdateAsync(Adress adress);
        Task<IResult> DeleteAsync(Adress adress);

    }
}