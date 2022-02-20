using DDD.Domain.OrderAggregate;
using System.Collections.Generic;

namespace DDD.Domain.Core.Repositories
{
    public interface IOrderRepository<T> where T : IAggregateRoot
    {
        void Insert(T order);
        List<Order> Get();
    }
}
