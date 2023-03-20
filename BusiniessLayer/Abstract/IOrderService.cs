using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreLayer.Utilities.Result;
using EntityLayer.Concrete;

namespace BusiniessLayer.Abstract
{
    public interface IOrderService
    {
        Task<IDataResult<Order>> AddAsync(Order order);
        Task<IDataResult<List<Order>>> GetListOrder();
        Task<IDataResult<Order>> GetOrderId(int Id);
         Task<IDataResult<Order>> GetOrderIdByUser(int Id);
    }
}