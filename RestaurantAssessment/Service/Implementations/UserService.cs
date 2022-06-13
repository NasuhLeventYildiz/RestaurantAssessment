using Common.DTOs.User;
using Common.Enums;
using DAL.Entities;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implementations
{
    public class UserService : IUserService
    {
        private readonly List<UserDto> users = new()
        {
            new UserDto { UserName = "rest", Id = Guid.NewGuid(), Password = "rest", UserType = UserType.Restaurant },
            new UserDto { UserName = "cus", Id = Guid.NewGuid(), Password = "cus", UserType = UserType.Customer },
            new UserDto { UserName = "guest", Id = Guid.NewGuid(), Password = "guest", UserType = UserType.Customer }
        };

        public void CreateUser(UserDto user)
        {
            this.users.Add(user);
        }

        public void DeleteUser(Guid id)
        {
            var index = this.users.FindIndex(existingItem => existingItem.Id == id);
            this.users.RemoveAt(index);
        }

        public UserDto GetUser(string userName, string password)
        {
            return this.users.FirstOrDefault(x => x.UserName.Equals(userName) && x.Password.Equals(password));
        }

        public UserDto GetUserById(Guid id)
        {
            return this.users.FirstOrDefault(existingItem => existingItem.Id == id);
        }

        public void UpdateUser(UserDto user)
        {
            var index = this.users.FindIndex(existingItem => existingItem.Id == user.Id);
            this.users[index] = user;
        }
    }
}
