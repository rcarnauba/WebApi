using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using FCamara.Service.Autenticacao.Token.Interfaces;

namespace FCamara.Service.Autenticacao.Token
{
    public class TokenService : ITokenService
    {
        private const string chaveJwt = "db3OIsj+BXE9NZDy0t8W3TcNekrF+2d/1sFnWG4HnV8TZY30iTOdtVWJG8abWvB1GlOgJuQZdcF2Luqm/hccMw==";

        public string GerarToken(string email, int tempoExpiracao)
        {
            var symmetricKey = Convert.FromBase64String(chaveJwt);
            var tokenHandler = new JwtSecurityTokenHandler();

            var now = DateTime.UtcNow;
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                        {
                        new Claim(ClaimTypes.Name, email)
                    }),

                Expires = now.AddMinutes(Convert.ToInt32(tempoExpiracao)),

                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(symmetricKey), SecurityAlgorithms.HmacSha256Signature)
            };

            var stoken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(stoken);

            return token;
        }

        public string ValidarToken(string tokenToValidate)
        {         
            var jwthandler = new JwtSecurityTokenHandler();
            var jwttoken = jwthandler.ReadToken(tokenToValidate);
            var expDate = jwttoken.ValidTo;
            if (expDate.ToLocalTime() > DateTime.Now)
                return tokenToValidate;

            return String.Empty;  
        }

    }
}
