using Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs.Menu
{
    public record UpdateMenuItemDto
    {
        [Required]
        public Guid Id { get; init; }
        [Required]
        [Range(0, 4)]
        public MenuItemType MenuItemType    { get; set; }
        [Required]
        public string Name                  { get; set; }
        [Required]
        [Range(0, 9999.99)]
        public double Price                 { get; set; }
        [Required]
        [Range(0, 6)]
        public DayOfWeek DayOfWeek          { get; set; }
        public string Description           { get; set; }
    }
}
