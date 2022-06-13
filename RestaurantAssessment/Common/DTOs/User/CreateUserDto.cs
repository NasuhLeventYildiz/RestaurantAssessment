using Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs.User
{
    public record CreateUserDto
    {
        [Required]
        public string UserName      { get; set; }
        [Required]
        public string Password      { get; set; }
        [Required]
        [Range(1, 3)]
        public UserType UserType    { get; set; }
    }
}
