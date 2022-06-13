using Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public record MenuItem
    {
        public Guid Id                      { get; init; }
        public MenuItemType MenuItemType    { get; init; }
        public string Name                  { get; set; }
        public double Price                 { get; set; }
        public DayOfWeek DayOfWeek          { get; set; }
        public string Description           { get; set; }
    }
}
