using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusiniessLayer.Abstract;
using BusiniessLayer.Contacts;
using CoreLayer.Utilities.Result;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusiniessLayer.Concrete
{
    public class OfferManager : IOfferService
    {
        private readonly IOfferDal _offerDal;

        public OfferManager(IOfferDal offerDal)
        {
            _offerDal = offerDal;
        }

        public async Task<IDataResult<Offer>> AddAsync(Offer offer)
        {
            await _offerDal.AddAsync(offer);
            return new SuccessDataResult<Offer>(offer, Messages.AddMessage);
        }

        public async Task<IResult> DeleteAsync(Offer offer)
        {
            await _offerDal.UpdateAsync(offer);
             return new SuccessResult(Messages.DeleteMessage);
        }

        public async Task<IDataResult<Offer>> GetById(int UserId)
        {
           var row = await _offerDal.GetFirstOrDefaultAsync(x=>x.Id ==UserId);
            if (row != null)
            {
                return new SuccessDataResult<Offer>(row);
            }
            return new ErrorDataResult<Offer>(new Offer(), Messages.RecordMessage);
        }

        public async Task<IDataResult<Offer>> GetIdByTaken(int UserId)
        {
           var row = await _offerDal.GetFirstOrDefaultAsync(x=>x.TakeUserId == UserId);
            if (row != null)
            {
                return new SuccessDataResult<Offer>(row);
            }
            return new ErrorDataResult<Offer>(new Offer(), Messages.RecordMessage);
        }

        public async Task<IDataResult<List<Offer>>> GetOfferList(int UserId)
        {
            var list = await _offerDal.GetListAsync(x=>x.TakeUserId == UserId && x.IsActived==true);
            return new SuccessDataResult<List<Offer>>(list.ToList());
        }
    }
}