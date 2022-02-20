using DDD.Domain.Core;
using DDD.Domain.Core.Repositories;
using DDD.Domain.OrderAggregate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DDD.Infrastructure.Repositories
{
    public class OrderRepository<T> : IOrderRepository<T> where T : class, IAggregateRoot
    {
        private readonly OrderDBContext _context;
        public OrderRepository(OrderDBContext context)
        {
            _context = context;
        }

        public List<Order> Get()
        {
            return _context.Orders.Include(i=>i.OrderItems).Include(i=>i.Address).ToList();

        }

        public void Insert(T order)
        {
            _context.Set<T>().Add(order);
            _context.SaveChanges();
        }
    }
}
