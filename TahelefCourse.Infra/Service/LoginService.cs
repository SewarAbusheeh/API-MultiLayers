using Dapper;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Tahelef.Core.Models;
using Tahelef.Core.Repository;
using Tahelef.Core.Service;

namespace TahelefCourse.Infra.Service
{
    public class LoginService : ILoginService
    {
        public readonly ILoginRepository loginRepository;
        public LoginService(ILoginRepository loginRepository)
        {
            this.loginRepository = loginRepository;
        }
        public string GenerateToken(Login login)          // return token value
        {
            var idintity = loginRepository.GenerateToken(login); //return roleid and username if they match
            if (idintity == null)
            {
                return null;
            }
            else
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var claims = new List<Claim>
                {
                new Claim(ClaimTypes.Name, idintity.Username),
                new Claim(ClaimTypes.Role, idintity.Roleid.ToString())
               };
                var tokeOptions = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddHours(24), signingCredentials: signinCredentials
);
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                return tokenString;
            }
        }

    }

}
    

