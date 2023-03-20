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
    public class CartManager : ICartService
    {
        private readonly ICartDal _cartDal;

        public CartManager(ICartDal cartDal)
        {
            _cartDal = cartDal;
        }

        public async Task<IDataResult<Cart>> AddAsync(Cart cart)
        {
            await _cartDal.AddAsync(cart);
            return new SuccessDataResult<Cart>(cart, Messages.AddMessage);
        }

        public async Task<IResult> DeleteAsync(Cart cart)
        {
            await _cartDal.UpdateAsync(cart);
            return new SuccessDataResult<Cart>(Messages.DeleteMessage);
        }



        public async Task<IDataResult<Cart>> GetCartIdByUser(int Id)
        {
            var row = await _cartDal.GetFirstOrDefaultAsync(x => x.UserId == Id);
            if (row != null)
            {
                return new SuccessDataResult<Cart>(row);
            }
            return new ErrorDataResult<Cart>(new Cart(), Messages.RecordMessage);
        }

        public async Task<IDataResult<List<Cart>>> GetCartListAsync(int Id)
        {
            return new SuccessDataResult<List<Cart>>((await _cartDal.GetListAsync(x => x.IsActived == true && x.UserId == Id)).ToList());
        }

        public async Task<IDataResult<List<Cart>>> GetCartListByOrderAsync(int Id)
        {
            var list = await _cartDal.GetListAsync(x=>x.Id == x.Order.CartId && x.IsActived == true && x.UserId == Id);
            return new SuccessDataResult<List<Cart>>(list.ToList());
        }

        public async Task<IResult> UpdateAsync(Cart cart)
        {
            await _cartDal.UpdateAsync(cart);
            return new SuccessDataResult<Cart>(cart, Messages.UpdateMessage);
        }
    }
}