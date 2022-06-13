using Common.DTOs.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IOrderService
    {
        void CreateOrder(OrderDto order);
        IEnumerable<OrderDto> GetAllOrders();
        IEnumerable<OrderDto> GetCustomerOrders(Guid userId);
        OrderDto GetOrdersByOrderId(Guid orderId);
    }
}
