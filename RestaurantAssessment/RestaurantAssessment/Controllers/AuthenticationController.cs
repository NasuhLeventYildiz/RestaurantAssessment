using Common.DTOs.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAssessment.Controllers
{
    [ApiController]
    [Route("authentication")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService authService;


        public AuthenticationController(IAuthenticationService authService)
        {
            this.authService = authService;
        }


        [AllowAnonymous]
        [HttpPost]
        public AuthResponseDto Login([FromBody] AuthRequestDto authRequest)
        {
            var response = authService.Login(authRequest);
            SetTokenCookie(response.Token, DateTime.Now.AddDays(1));
            return response;
        }


        private void SetTokenCookie(string token, DateTime expirationDate)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = expirationDate,
            };
            HttpContext.Response.Cookies.Append("refreshToken", token, cookieOptions);
        }



    }
}
