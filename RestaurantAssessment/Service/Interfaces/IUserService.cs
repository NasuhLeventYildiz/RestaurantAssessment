using Common.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IUserService
    {
        UserDto GetUser(string loginName, string password);
        void CreateUser(UserDto user);
        void UpdateUser(UserDto user);
        void DeleteUser(Guid id);
        UserDto GetUserById(Guid id);
    }
}
