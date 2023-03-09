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
        Task<IDataResult<List<Adress>>> GetAdressList(int Id);
        Task<IDataResult<Adress>> GetById(int Id, int UserId);

        Task<IResult> UpdateAsync(Adress adress);
        Task<IResult> DeleteAsync(Adress adress);

    }
}