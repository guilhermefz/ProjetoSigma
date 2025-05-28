using Microsoft.AspNetCore.Mvc;
using Sigma.Application.Interfaces;
using Sigma.Domain.Entities;

namespace Sigma.API.Controllers
{
    public class AuthController : Controller
    {
        private readonly IConfiguration _config;
        private readonly IProjetoService _projetoService;

        public AuthController(IConfiguration config, IProjetoService projetoService)
        {
            _config = config;
            _projetoService = projetoService;
        }
        [HttpPost("Login")]
        public IActionResult Login([FromBody] Usuario usuario)
        {
            if (usuario.Username == "admin" && usuario.Password == "123")
            {
                var token = _projetoService.GerarToken(usuario.Username);
                return Ok(new { token });
            }
            return Unauthorized();
        }
    }
}
 