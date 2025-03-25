using EmergencyNavigation.Core.Model;
using EmergencyNavigation.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EmergencyNavigation.API.Controllers
{
    [Route("api/controller")]
    [ApiController]
   // [Authoriza]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;
        public AuthController(IConfiguration configuration,IUserService userService)
        {
            _configuration = configuration;
            _userService= userService;
        }



        [HttpPost]
        public IActionResult Login([FromBody] LoginModel user)
        {
            User u = _userService.GetUserByEmail(user.Email);
            if (u == null)
            {
                return NotFound();
            }
            if(u.Password.Equals(user.Password)) {
                var secretKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_configuration.GetValue<string>("JWT:Key"))
                );

                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var tokenOptions = new JwtSecurityToken(
                    issuer: _configuration.GetValue<string>("JWT:Issuer"),
                    audience: _configuration.GetValue<string>("JWT:Audience"),
                    //claims: claims,
                    expires: DateTime.Now.AddMinutes(20),
                    signingCredentials: signinCredentials
                );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

                return Ok(new { Token = tokenString ,User=u });
            }

            return Unauthorized();
        }



    }
}
