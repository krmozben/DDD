using DDD.Domain.Core.Repositories;
using DDD.Domain.OrderAggregate;
using DDD.Services.Interfaces;
using System.Collections.Generic;

namespace DDD.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository<Order> _orderRepository;

        public OrderService(IOrderRepository<Order> orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public List<Order> Get()
        {
            return _orderRepository.Get();
        }

        public void Insert()
        {
            Order order = new Order("kerim.ozben", new Address("istanbul", "bahçelievler", "merkez", "123456", "line"));
            order.AddOrderItem("CK6134","laptop",12.45m,"resim adresi");
            _orderRepository.Insert(order);
        }
    }
}
