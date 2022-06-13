using Common.DTOs.Menu;
using Common.DTOs.Order;
using Common.DTOs.User;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Extensions
{
    public static class Extensions
    {
        public static OrderDto AsOrderDto(this Order item)
        {
            OrderItemDto itemDto = null;
            List<OrderItemDto> orderItemDtoList = new List<OrderItemDto>();
            foreach (OrderItem orderItem in item.OrderItems)
            {
                itemDto = new OrderItemDto { Count = orderItem.Count, MenuItemId = orderItem.MenuItemId };
                orderItemDtoList.Add(itemDto);
            }
            return new OrderDto
            {
                Id = item.Id,
                OrderItems = orderItemDtoList,
                CustomerId = item.UserId,
                OrderDate = item.OrderDate
            };
        }

        public static OrderItemDto AsOrderItemDto(this OrderItem item)
        {
            return new OrderItemDto
            {
                MenuItemId = item.MenuItemId,
                Count = item.Count
            };
        }
        public static MenuItemDto AsMenuItemDto(this MenuItem item)
        {
            return new MenuItemDto
            {
                Id = item.Id,
                DayOfWeek = item.DayOfWeek,
                MenuItemType = item.MenuItemType,
                Name = item.Name,
                Description = item.Description,
                Price = item.Price,
            };
        }

        public static MenuItem AsMenuItem(this MenuItemDto item)
        {
            return new MenuItem
            {
                Id = item.Id,
                DayOfWeek = item.DayOfWeek,
                MenuItemType = item.MenuItemType,
                Name = item.Name,
                Description = item.Description,
                Price = item.Price,
            };
        }
        public static UserDto AsUserDto(this User item)
        {
            return new UserDto
            {
                Id = item.Id,
                Password = item.Password,
                UserName = item.UserName,
                UserType = item.UserType,
                Token = item.Token,
            };

        }
    }
}
