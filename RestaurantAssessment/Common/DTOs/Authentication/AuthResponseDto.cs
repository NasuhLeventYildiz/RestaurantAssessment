using Common.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs.Authentication
{
    public record AuthResponseDto
    {
        public Guid Id          { get; set; }
        public string Username  { get; set; }
        public string Password  { get; set; }
        public string Token     { get; set; }


        public AuthResponseDto(UserDto user, string token)
        {
            Id          = user.Id;
            Username    = user.UserName;
            Token       = token;
        }
    }
}
