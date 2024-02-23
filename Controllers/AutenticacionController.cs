using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using VehiculoBack.Models;

namespace VehiculoBack.Controllers
{
    public class AutenticacionController : ControllerBase
    {
        private readonly string secretkey;
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public AutenticacionController(ApplicationDbContext context, IMapper mapper, IConfiguration config)
        {
            this.context = context;
            this.mapper = mapper;
            secretkey = config.GetSection("settings").GetSection("secretkey").ToString();
        }

        [HttpPost]
        [Route("Validar")]

        public async Task<ActionResult<List<Usuarios>>> Post ([FromBody] Usuarios request)
        {
            var validarUsuario = await context.Usuarios.AnyAsync(x => x.Email == request.Email && x.Contraseña == request.Contraseña);

            if (validarUsuario)
            {

                var ConsultaUsuarios = await context.Usuarios
                 .Where(x => x.Email == request.Email && x.Contraseña == request.Contraseña)
                .ToListAsync();
                var result = mapper.Map<List<Usuarios>>(ConsultaUsuarios);

                var KeyBytes = Encoding.UTF8.GetBytes(secretkey);
                var claims = new ClaimsIdentity();

                claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, request.Email));

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = claims,
                    Expires = DateTime.UtcNow.AddHours(24),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(KeyBytes), SecurityAlgorithms.HmacSha256Signature)

                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenConfig = tokenHandler.CreateToken(tokenDescriptor);

                string tokenCreado = tokenHandler.WriteToken(tokenConfig);

                return StatusCode(StatusCodes.Status200OK, new { token = tokenCreado, Usuario = result });
            }

             else
            {
                return StatusCode(StatusCodes.Status401Unauthorized, new { token = "" });
            }



        }

    }
}
