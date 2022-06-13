using Common.DTOs.User;
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
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        public UserController(IUserService userService)
        {
            this.userService = userService;
        }
        
        [HttpPost]
        public ActionResult<UserDto> CreateUser(CreateUserDto createUserDto)
        {
            UserDto userDto = new UserDto
            {
                Id = Guid.NewGuid(),
                Password = createUserDto.Password,
                UserName = createUserDto.UserName,
                UserType = createUserDto.UserType,
            };
            userService.CreateUser(userDto);
            return CreatedAtAction(nameof(GetUserById), new { id = userDto.Id}, userDto);
        }

        
        [HttpGet]
        public ActionResult<UserDto> GetUserById(Guid id)
        {
            var item = userService.GetUserById(id);
            if(item is null)
            {
                return NotFound();
            }
            return item;
        }
    }
}
