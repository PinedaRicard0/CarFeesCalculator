using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using TOTAL_CAR_FEES.API.Models;

namespace TOTAL_CAR_FEES.API.Controllers
{
    [ApiController]
	[Route("api/auth")]
    public class TokenAccesController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public TokenAccesController(IConfiguration configuration)
		{
            _configuration = configuration;

        }

        [HttpPost("token")]
        public IActionResult GetToken(UserToken userToken)
        {
            string userJWT = _configuration.GetValue<string>("JWTAttributes:UserJWT");
            string passJWT = _configuration.GetValue<string>("JWTAttributes:PassJWT");
            int expiresInMinutes = 30;
            if (userJWT.Equals(userToken.Username) && passJWT.Equals(userToken.Password))
            {
                string issuer = _configuration.GetValue<string>("JWTAttributes:Issuer");
                string audience = _configuration.GetValue<string>("JWTAttributes:Audience");
                byte[] key = Encoding.ASCII.GetBytes(_configuration.GetValue<string>("JWTAttributes:Key"));
                SecurityTokenDescriptor tokenDescriptor = new ()
                {
                    Subject = new ClaimsIdentity(new[]
                    {
                        new Claim("Id", Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Sub, userToken.Username),
                        new Claim(JwtRegisteredClaimNames.Email, userToken.Username),
                        new Claim(JwtRegisteredClaimNames.Jti,
                        Guid.NewGuid().ToString())
                    }),
                    Expires = DateTime.UtcNow.AddMinutes(expiresInMinutes),
                    Issuer = issuer,
                    Audience = audience,
                    SigningCredentials = new SigningCredentials
                    (new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha512Signature)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var jwtToken = tokenHandler.WriteToken(token);
                var stringToken = tokenHandler.WriteToken(token);
                return Ok(new { token = stringToken, expires_in_seconds = (expiresInMinutes * 60), token_type = "Bearer" });
            }
            return Unauthorized();
        }
	}
}