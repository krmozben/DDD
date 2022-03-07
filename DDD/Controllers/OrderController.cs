using DDD.Domain.OrderAggregate;
using DDD.Services;
using DDD.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DDD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public ActionResult GetOrder()
        {
            _orderService.Insert();
            return Ok();
        }

        [HttpGet("Getir")]
        public List<Order> Getir()
        {
            return _orderService.Get();
        }
    }
}
