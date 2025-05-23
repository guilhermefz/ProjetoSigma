using Microsoft.AspNetCore.Mvc;
using Sigma.Application.Interfaces;
using Sigma.Domain.Dtos;
using Sigma.Infra.Data.Context;


namespace Sigma.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjetoController : ControllerBase
    {
        private readonly IProjetoService _projetoService;
        private readonly SigmaContext _context;

        public ProjetoController(IProjetoService projetoService, SigmaContext context)
        {
            _projetoService = projetoService;
            _context = context; 
        }

        [HttpPost]
        [Route("inserir")]
        public async Task<IActionResult> Inserir([FromBody] ProjetoNovoDto model)
        {
            return new JsonResult(await _projetoService.Inserir(model));
        }

        [HttpGet]
        [Route("listar")]
        public async Task<IActionResult> Listar()
        {
            var resultado = await _projetoService.Listar();
            return Ok(resultado);
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto model)
        {
            // Consulta o usuário no banco de forma async
            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Username == model.Username && u.Password == model.Password);

            if (usuario == null)
                return Unauthorized("Usuário ou senha inválidos");

            var token = GerarToken(usuario.Username);

            return Ok(new { token });
        }

    }
}
