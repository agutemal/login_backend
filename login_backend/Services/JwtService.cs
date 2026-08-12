using login_backend.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace login_backend.Services
{
    public class JwtService : IJwtService
    {
        private readonly IConfiguration _configuration;
        public JwtService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GenerateToken(User user)
        {
            // Paso 1: Leer la configuración del JWT desde appsettings.json
            //   "Jwt": { "Key": "...", "Issuer": "...", "Audience": "...", "ExpireMinutes": 60 }
            var key = _configuration["Jwt:Key"]!;
            var issuer = _configuration["Jwt:Issuer"];
            var audience = _configuration["Jwt:Audience"];
            var expireMinutes = int.Parse(_configuration["Jwt:ExpireMinutes"]!);

            // Paso 2: Definir los "claims" (afirmaciones/datos) que va a llevar el token
            // Esto es la información que podrás leer después desde User.Claims
            // en cualquier controller protegido, sin volver a consultar la base de datos
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Name, user.UserName)
            };

            // Paso 3: Crear la clave de firma a partir del texto secreto en appsettings.json
            // Esta clave es la que garantiza que el token no pueda ser falsificado
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // Paso 4: Armar el token con todos sus componentes
            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(expireMinutes),
                signingCredentials: credentials
            );

            // Paso 5: Convertir el objeto token en el string final
            // que se envía al cliente (el JWT que verás en Postman)
            return new JwtSecurityTokenHandler().WriteToken(token);
        }


    }
}
