using Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs.User
{
    public record UserDto
    {
        public Guid Id              { get; init; }
        public string UserName      { get; set; }
        public string Password      { get; set; }
        public UserType UserType    { get; set; }
        public string Token         { get; set; }
    }
}
