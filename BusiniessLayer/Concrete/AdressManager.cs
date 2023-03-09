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
    public class AdressManager : IAdressService
    {
        private readonly IAdressDal _adressDal;

        public AdressManager(IAdressDal adressDal)
        {
            _adressDal = adressDal;
        }

        public async Task<IDataResult<Adress>> AddAsync(Adress adress)
        {
            await _adressDal.AddAsync(adress);
            return new SuccessDataResult<Adress>(adress, Messages.AddMessage);
        }

        public async Task<IResult> DeleteAsync(Adress adress)
        {
            await _adressDal.UpdateAsync(adress);
            return new SuccessDataResult<Adress>(Messages.DeleteMessage);
        }

        public async Task<IDataResult<List<Adress>>> GetAdressList(int Id)
        {
          var list = await _adressDal.GetListAsync(x=>x.IsActived == true && x.UserId == Id);
          return new SuccessDataResult<List<Adress>>(list.ToList());
        }

        public async Task<IDataResult<Adress>> GetById(int Id,int UserId)
        {
            var row = await _adressDal.GetFirstOrDefaultAsync(x => x.Id == Id && x.UserId == UserId);
            if(row != null)
            {
                return new SuccessDataResult<Adress>(row);
            }
            return new SuccessDataResult<Adress>(new Adress(), Messages.RecordMessage);
        }

        public async Task<IResult> UpdateAsync(Adress adress)
        {
            await _adressDal.UpdateAsync(adress);
            return new SuccessDataResult<Adress>(adress,Messages.AddMessage);
        }
    }
}