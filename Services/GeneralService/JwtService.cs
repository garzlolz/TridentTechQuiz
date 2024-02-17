using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TridentTech.Services.Interface;

namespace TridentTech.Services.GeneralService
{
    public class JwtService : IJwtService
    {
        private readonly byte[] _jwtKey;
        private static readonly JwtSecurityTokenHandler _jwtTokenHandler = new();

        public JwtService(IConfiguration configuration)
        {
            _jwtKey = Encoding.UTF8.GetBytes(configuration["JwtSettings:SignKey"] ?? null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="expiredMinutes"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public string GetApiJwt(int userId, bool isTeacher, int expiredMinutes = 1440)
        {
            var descriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
                    new Claim(ClaimTypes.Role, isTeacher.ToString())
                }),
                Expires = DateTime.Now.AddMinutes(expiredMinutes),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(_jwtKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = _jwtTokenHandler.CreateToken(descriptor);
            return _jwtTokenHandler.WriteToken(token);
        }
    }
}
