using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Agendamento.Models;
using Microsoft.IdentityModel.Tokens;

namespace Agendamento.Services
{
    public class TokenService
    {
        public string Generate(User user)
        {
            //Cria uma instancia do JWT 
            var handler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Configuration.privateKey);
            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = GenereteClaims(user),
                SigningCredentials = credentials,
                Expires = DateTime.UtcNow.AddHours(2),
            };
            //Gera um token
            var token = handler.CreateToken(tokenDescriptor);
            //Gera uma string do Token
            return handler.WriteToken(token);
        }

        private static ClaimsIdentity GenereteClaims(User user)
        {
            var ci = new ClaimsIdentity();
            ci.AddClaim(new Claim(ClaimTypes.Name, user.Email));
            foreach (var Roles in user.Roles)

                ci.AddClaim(new Claim(ClaimTypes.Role, Roles));

            return ci;

        }
    }
}