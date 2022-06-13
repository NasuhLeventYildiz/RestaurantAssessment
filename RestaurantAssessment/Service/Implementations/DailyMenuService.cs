using Common.DTOs.Menu;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implementations
{
    public class DailyMenuService : IDailyMenuService
    {
        private readonly List<MenuItemDto> menus = new List<MenuItemDto>();
        public void CreateDailyMenu(List<MenuItemDto> menuItems)
        {
            menus.AddRange(menuItems);
        }
        public IEnumerable<MenuItemDto> GetDailyMenu(DayOfWeek dayOfWeek)
        {
            return menus.Where(x => x.DayOfWeek == dayOfWeek);
        }
        public void DeleteMenuItem(List<MenuItemDto> menuItems)
        {
            foreach (var item in menuItems)
            {
                var index = menus.FindIndex(existingItem => existingItem.Id == item.Id);
                menus.RemoveAt(index);
            }
        }        
        public void UpdateMenuItems(List<MenuItemDto> menuItems)
        {
            foreach (MenuItemDto item in menuItems)
            {
                var index = this.menus.FindIndex(existingItem => existingItem.Id == item.Id);
                this.menus[index] = item;
            }
        }
    }
}
