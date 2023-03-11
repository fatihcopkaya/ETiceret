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
    public class OrderManager : IOrderService
    {
        private readonly IOrderDal _orderDal;

        public OrderManager(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }

        public async Task<IDataResult<Order>> AddAsync(Order order)
        {
           await _orderDal.AddAsync(order);
           return new SuccessDataResult<Order>(order, Messages.AddMessage);
        }

        public async Task<IDataResult<List<Order>>> GetListOrder()
        {
            var list = await _orderDal.GetListAsync(x=>x.IsActived == true);
            return new SuccessDataResult<List<Order>>(list.ToList());
        }

        public async Task<IDataResult<Order>> GetOrderId(int Id)
        {
           var row = await _orderDal.GetFirstOrDefaultAsync(x=>x.Id == Id);
          if (row != null)
            {
                return new SuccessDataResult<Order>(row);
            }
              return new ErrorDataResult<Order>(new Order(), Messages.RecordMessage);
        }
    }
}