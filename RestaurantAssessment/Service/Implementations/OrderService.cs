using Common.DTOs.Order;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly List<OrderDto> orders = new List<OrderDto>();
        public void CreateOrder(OrderDto order)
        {
            orders.Add(order);
        }

        public IEnumerable<OrderDto> GetAllOrders()
        {
            return orders;
        }

        public OrderDto GetOrdersByOrderId(Guid orderId)
        {
            return orders.FirstOrDefault(x => x.Id.Equals(orderId));
        }

        public IEnumerable<OrderDto> GetCustomerOrders(Guid userId)
        {
            return orders.Where(x => x.CustomerId.Equals(userId));
        }

    }
}
