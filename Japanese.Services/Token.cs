using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Japanese.Services
{
    public class Token
    {
        private readonly ConfigurationJWT _configurationJWT;
        public Token(ConfigurationJWT configurationJWT)
        {
            _configurationJWT= configurationJWT;
        }

        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configurationJWT.Secret));

            var token = new JwtSecurityToken(
                issuer: _configurationJWT.ValidIssuer,
                audience: _configurationJWT.ValidAudience,
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }

    }
}
