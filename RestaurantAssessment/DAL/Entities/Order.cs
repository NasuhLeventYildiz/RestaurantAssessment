using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public record Order
    {
        public Guid Id                      { get; init; }
        public Guid UserId                  { get; init; }
        public List<OrderItem> OrderItems   { get; init; }
        public DateTime OrderDate           { get; init; }
    }
}
