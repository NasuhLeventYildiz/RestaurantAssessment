using Common.DTOs.Menu;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAssessment.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class MenuController : ControllerBase
    {
        private readonly IDailyMenuService dailyMenuService;

        public MenuController(IDailyMenuService dailyMenuService)
        {
            this.dailyMenuService = dailyMenuService;
        }

        //GET /Menu
        [HttpGet]
        public IEnumerable<MenuItemDto> GetDailyMenu(DayOfWeek dayOfWeek)
        {

            var items = dailyMenuService.GetDailyMenu(dayOfWeek);
            return items;
        }

        //POST /Menu
        [HttpPost()]
        [Authorize(Roles = "Restaurant")]
        public ActionResult<MenuItemDto> CreateDailyMenu(List<CreateMenuItemDto> menuItems)
        {
            MenuItemDto menu = null;
            List<MenuItemDto> menuList = new List<MenuItemDto>();
            foreach (CreateMenuItemDto item in menuItems)
            {
                menu = new MenuItemDto
                {
                    DayOfWeek       = item.DayOfWeek,
                    Id              = Guid.NewGuid(),
                    MenuItemType    = item.MenuItemType,
                    Name            = item.Name,
                    Price           = item.Price,
                    Description     = item.Description
                };
                menuList.Add(menu);
            }

            this.dailyMenuService.CreateDailyMenu(menuList);
            return CreatedAtAction(nameof(GetDailyMenu), new { dayOfWeek = menuItems[0].DayOfWeek }, menuList);

        }

        //Delete /Menu
        [HttpDelete()]
        [Authorize]
        [Authorize(Roles = "Restaurant")]
        public ActionResult DeleteMenuItem(DayOfWeek dayOfWeek)
        {
            var existingItem = this.dailyMenuService.GetDailyMenu(dayOfWeek);
            if (existingItem is null)
            {
                return NotFound();
            }
            this.dailyMenuService.DeleteMenuItem(existingItem.ToList());
            return NoContent();
        }


        //Put /Menu
        [HttpPut("id")]
        [Authorize]
        [Authorize(Roles = "Admin,Restaurant")]
        public ActionResult UpdateMenuItems(DayOfWeek dayOfWeek, List<UpdateMenuItemDto> updateMenuItemDtos)
        {
            List<MenuItemDto> menuItems = new List<MenuItemDto>();
            var existingItem = this.dailyMenuService.GetDailyMenu(dayOfWeek);
            if (existingItem is null)
            {
                return NotFound();
            }

            foreach (MenuItemDto item in existingItem)
            {
                UpdateMenuItemDto updateMenuItemDto = updateMenuItemDtos.FirstOrDefault(x => x.Id == item.Id);
                if (updateMenuItemDto != null)
                {
                    MenuItemDto updateItem = item with
                    {
                        Name            = updateMenuItemDto.Name,
                        MenuItemType    = updateMenuItemDto.MenuItemType,
                        DayOfWeek       = updateMenuItemDto.DayOfWeek,
                        Description     = updateMenuItemDto.Description,
                        Price           = updateMenuItemDto.Price,
                    };
                    menuItems.Add(updateItem);
                }
            }
            this.dailyMenuService.UpdateMenuItems(menuItems);
            return NoContent();

        }
    }
}
