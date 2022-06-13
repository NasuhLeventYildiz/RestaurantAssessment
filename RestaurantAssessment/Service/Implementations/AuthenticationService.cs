using Common.DTOs.Authentication;
using Common.Enums;
using Common.Exceptions;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Service.Extensions;
using Common.DTOs.User;
using System.Security.Claims;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace Service.Implementations
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserService userService;

        public AuthenticationService(IUserService userService)
        {
            this.userService = userService;
        }
        public AuthResponseDto Login(AuthRequestDto login)
        {
            if (login == null)
            {
                throw new HttpStatusCodeException { CustomMessage = "Invalid request body! AuthRequestDto is null!", StatusCode = HttpStatusCode.BadRequest, ErrorCode = ErrorCode.Unknown };
            }
            else if (string.IsNullOrEmpty(login.Username) || string.IsNullOrEmpty(login.Password))
                throw new HttpStatusCodeException { CustomMessage = "Username or password is incorrect!", StatusCode = HttpStatusCode.BadRequest, ErrorCode = ErrorCode.UserNameOrPasswordError };

            var user = this.userService.GetUser(login.Username.Trim().ToLower(), login.Password.Trim().ToLower());

            if (user == null)
            {
                throw new HttpStatusCodeException { CustomMessage = "Username or password is incorrect!", StatusCode = HttpStatusCode.BadRequest, ErrorCode = ErrorCode.UserNameOrPasswordError };
            };

            var userDto = new UserDto
            {
                Id          = user.Id,
                Password    = user.Password,
                UserName    = user.UserName,
                UserType    = user.UserType,
                Token       = user.Token,
            };

            //Session yapısı eklendiğinde Guid yerine sesionId oluşturulup o yollanır.
            var token = FillToken(userDto, Guid.NewGuid().ToString());
            userDto.Token = token;
            return new AuthResponseDto(userDto, token);
        }


        public static UserDto GetUserData(ClaimsPrincipal user)
        {
            Claim userDto = user?.Claims.FirstOrDefault(x => x.Type == ClaimTypes.UserData);
            if (userDto == null)
            {
                throw new HttpStatusCodeException { CustomMessage = "User is not logged in!", StatusCode = HttpStatusCode.Unauthorized, ErrorCode = ErrorCode.NotLoggedIn };
            };
            return JsonConvert.DeserializeObject<UserDto>(userDto.Value);
        }

        private string FillToken(UserDto userDto, string sessionId)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, userDto.UserName, ClaimValueTypes.String, string.Empty),
                new Claim(ClaimTypes.NameIdentifier, userDto.Id.ToString(), ClaimValueTypes.String, string.Empty),
                new Claim(ClaimTypes.Sid, sessionId, ClaimValueTypes.Sid),
                new Claim(ClaimTypes.UserData, JsonConvert.SerializeObject(userDto), ClaimValueTypes.String, string.Empty),
                new Claim(ClaimTypes.Role, userDto.UserType.ToString(), ClaimValueTypes.String, string.Empty),
                new Claim(JwtRegisteredClaimNames.Sub, userDto.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("example_app_secret")), SecurityAlgorithms.HmacSha256);
            var tokenOptions = new JwtSecurityToken(
                issuer: "example_app_id",
                audience: "leventRestaurantAssessment",
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: signingCredentials
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            return tokenString;
        }
    }
}
