using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sigma.Application.Dtos;
using Sigma.Application.Interfaces;
using Sigma.Domain.Dtos;
using Sigma.Domain.Entities;
using Sigma.Infra.Data.Context;
using Sigma.Infra.Data.Migrations;


namespace Sigma.API.Controllers
{
    [Authorize]
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

        [HttpPut]
        [Route("Editar")]
        public async Task<IActionResult> Editar ([FromBody]ProjetoDto projetoDto)
        {
            await _projetoService.Editar(projetoDto);
            return Ok();
        }

        [HttpGet]
        [Route("Consultar")]
        public async Task<IActionResult> ConsultarAsync(string nome)
        {
            var projeto = await _projetoService.ConsultarAsync(nome);
            if (projeto == null || projeto.Count == 0)
                return NotFound("Projeto não encontrado.");
            return Ok(projeto);
        }

        [HttpDelete]
        [Route("Deletar")]
        public async Task<IActionResult> DeletarPorIdAsync(long id)
        {
            await _projetoService.DeletarPorId(id);
            return Ok();
        }

        
       

    }
}
