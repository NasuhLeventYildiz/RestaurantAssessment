using Common.DTOs.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IDailyMenuService
    {
        IEnumerable<MenuItemDto> GetDailyMenu(DayOfWeek dayOfWeek);
        void CreateDailyMenu(List<MenuItemDto> menuItems);
        void DeleteMenuItem(List<MenuItemDto> menuItems);
        void UpdateMenuItems(List<MenuItemDto> menuItems);
    }
}
