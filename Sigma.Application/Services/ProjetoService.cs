using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Sigma.Application.Dtos;
using Sigma.Application.Interfaces;
using Sigma.Domain.Dtos;
using Sigma.Domain.Entities;
using Sigma.Domain.Interfaces.Repositories;
using Sigma.Infra.Data.Context;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;


namespace Sigma.Application.Services
{
    public class ProjetoService : IProjetoService
    {
        private readonly SigmaContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IProjetoRepository _projetoRepository;
        private readonly IConfiguration _config;



        public ProjetoService(IMapper mapper, IProjetoRepository projetoRepository, SigmaContext dbContext, IConfiguration config)
        {
            _mapper = mapper;
            _projetoRepository = projetoRepository;
            _dbContext = dbContext;
            _config = config;
        }

        public async Task<bool> Inserir(ProjetoNovoDto model)
        {
            return await _projetoRepository.Inserir(_mapper.Map<Projeto>(model));
        }


        public async Task<List<ProjetoDto>> Listar()
        {
            var projetos = await _dbContext.Set<Projeto>().ToListAsync();

            return projetos.Select(p => new ProjetoDto
            {
                Id = (int)p.Id,
                Nome = p.Nome
            }).ToList();
        }

        public async Task<string> LoginAsync(string username, string password)
        {
            var usuario = await _dbContext.Usuarios
                .FirstOrDefaultAsync(u => u.Username == username && u.Password == password);

            if (usuario == null)
                return null;

            return GerarToken(usuario.Username);
        }

        private string GerarToken(string username)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
            new Claim(ClaimTypes.Name, username)
        };

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(30),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }


    }
}
