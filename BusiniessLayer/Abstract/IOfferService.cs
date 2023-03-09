using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreLayer.Utilities.Result;
using EntityLayer.Concrete;

namespace BusiniessLayer.Abstract
{
    public interface IOfferService 
    {
        Task<IDataResult<Offer>> AddAsync(Offer offer);
        Task<IDataResult<List<Offer>>> GetOfferList(int UserId); 
         Task<IDataResult<Offer>> GetById(int UserId); 
         Task<IResult> DeleteAsync(Offer offer);

        
    }
}