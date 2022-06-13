using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs.Order
{
    public record OrderDto
    {
        public Guid Id                          { get; init; }
        public Guid CustomerId                  { get; init; }
        public List<OrderItemDto> OrderItems    { get; init; }
        public DateTime OrderDate               { get; init; }
    }
}
