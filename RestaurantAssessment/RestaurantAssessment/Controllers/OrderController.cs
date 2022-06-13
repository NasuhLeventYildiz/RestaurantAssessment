using Common.DTOs.Order;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Implementations;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAssessment.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService orderService;
        protected readonly IHttpContextAccessor httpContextAccessor;
        private readonly IDailyMenuService dailyMenuService;
        public OrderController(IOrderService orderService, IHttpContextAccessor httpContextAccessor, IDailyMenuService dailyMenuService)
        {
            this.orderService           = orderService;
            this.httpContextAccessor    = httpContextAccessor;
            this.dailyMenuService       = dailyMenuService;
        }

        //GET /order/{id}
        [HttpGet("id")]
        [Authorize(Roles = "Restaurant,Customer")]
        public ActionResult<OrderDto> GetOrder(Guid orderId)
        {
            var item = this.orderService.GetOrdersByOrderId(orderId);
            if (item is null)
            {
                return NotFound();
            }
            return item;
        }

        //GET /order/{id}
        [HttpGet()]
        [Authorize(Roles = "Restaurant")]
        public IEnumerable<OrderDto> GetAllOrders()
        {
            var items = this.orderService.GetAllOrders();
            return items;
        }

        //POST /order
        [HttpPost()]
        [Authorize]
        [Authorize(Roles = "Customer")]
        public ActionResult<OrderDto> CreateOrder(CreateOrderDto dto)
        {  
            var user = AuthenticationService.GetUserData(httpContextAccessor.HttpContext.User);
            List<OrderItemDto> orderItems = new List<OrderItemDto>();
            foreach (var dtoItem in dto.OrderItemDtoList)
            {
                OrderItemDto orderItem = new OrderItemDto
                {
                    Count       = dtoItem.Count,
                    MenuItemId  = dtoItem.MenuItemId,
                };
                orderItems.Add(orderItem);
            }
            OrderDto order = new OrderDto
            {
                Id          = Guid.NewGuid(),
                OrderItems  = orderItems,
                OrderDate   = DateTime.Now,
                CustomerId  = user.Id,
            };
            this.orderService.CreateOrder(order);
            return CreatedAtAction(nameof(GetOrder), new { id = order.Id }, order);

        }

        //GET /order/{id}
        [HttpGet("id")]
        [Authorize(Roles = "Restaurant")]
        public IEnumerable<OrderDto> GetCustomerOrders(Guid customerId)
        {
            var items = this.orderService.GetCustomerOrders(customerId);
            return items;
        }

        //GET /order/
        [HttpGet()]
        [Authorize(Roles = "Customer")]
        public IEnumerable<OrderDto> GetOwnOrders()
        {
            var user = AuthenticationService.GetUserData(httpContextAccessor.HttpContext.User);
            var items = this.orderService.GetCustomerOrders(user.Id);
            return items;
        }

    }
}
