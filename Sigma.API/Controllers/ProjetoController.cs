using Microsoft.AspNetCore.Mvc;
using Sigma.Application.Interfaces;
using Sigma.Domain.Dtos;
using Sigma.Domain.Entities;
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

        
       

    }
}
