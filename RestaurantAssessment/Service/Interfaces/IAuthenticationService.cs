using Common.DTOs.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IAuthenticationService
    {
        AuthResponseDto Login(AuthRequestDto login);
    }
}
