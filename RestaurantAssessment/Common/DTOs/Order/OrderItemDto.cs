using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs.Order
{
    public record OrderItemDto
    {
        [Required]
        public Guid MenuItemId { get; set; }
        [Required]
        public short Count { get; set; }
    }
}
