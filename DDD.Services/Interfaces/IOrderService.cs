using DDD.Domain.OrderAggregate;
using System.Collections.Generic;

namespace DDD.Services.Interfaces
{
    public interface IOrderService
    {
        void Insert();
        List<Order> Get();
    }
}
