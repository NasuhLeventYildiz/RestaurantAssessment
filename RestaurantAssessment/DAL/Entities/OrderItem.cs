using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public record OrderItem
    {
        public Guid MenuItemId  { get; init; }
        public short Count      { get; init; }
    }
}
