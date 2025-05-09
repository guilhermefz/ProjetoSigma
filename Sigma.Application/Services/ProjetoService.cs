using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Sigma.Application.Dtos;
using Sigma.Application.Interfaces;
using Sigma.Domain.Dtos;
using Sigma.Domain.Entities;
using Sigma.Domain.Interfaces.Repositories;
using Sigma.Infra.Data.Context;

namespace Sigma.Application.Services
{
    public class ProjetoService : IProjetoService
    {
        private readonly SigmaContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IProjetoRepository _projetoRepository;

       

        public ProjetoService(IMapper mapper, IProjetoRepository projetoRepository, SigmaContext dbContext)
        {
            _mapper = mapper;
            _projetoRepository = projetoRepository;
            _dbContext = dbContext;
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


    }
}
