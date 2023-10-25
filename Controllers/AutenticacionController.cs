using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApiAlkemyPI.Models;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Data;

namespace ApiAlkemyPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutenticacionController : ControllerBase
    {
        private readonly string secretKey;
        private readonly AlkemyDbContext _context;
        public AutenticacionController(IConfiguration config, AlkemyDbContext context)
        {
            secretKey = config.GetSection("settings").GetSection("secretkey").ToString();
            _context = context;
        }

        [HttpPost]
        [Route("validar")]
        public async Task<IActionResult> Validar([FromBody] UsuariosModel request)
        {
            var usuariosModel = await _context.UsuariosModels.FindAsync(request.CodUsuario);
            if (usuariosModel == null)
            {
                return StatusCode(StatusCodes.Status401Unauthorized, new { token = "inexistente o inhabilitado" });
            }
            if (request.CodUsuario == usuariosModel.CodUsuario && request.Nombre == usuariosModel.Nombre)
            {
                var keyBytes = Encoding.ASCII.GetBytes(secretKey);
                var claims = new ClaimsIdentity();

                claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, request.CodUsuario.ToString()));

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = claims,
                    Expires = DateTime.UtcNow.AddMinutes(15),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256Signature),
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenConfig = tokenHandler.CreateToken(tokenDescriptor);

                string tokenCreado = tokenHandler.WriteToken(tokenConfig);

                return StatusCode(StatusCodes.Status200OK, new { token = tokenCreado });
            }
            else
            {
                return StatusCode(StatusCodes.Status401Unauthorized, new { token = "inexistente o inhabilitado" });
            }

        }
    }
}
