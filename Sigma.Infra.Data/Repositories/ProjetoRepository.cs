﻿using Microsoft.EntityFrameworkCore;
using Sigma.Domain.Entities;
using Sigma.Domain.Interfaces.Repositories;
using Sigma.Infra.Data.Context;

namespace Sigma.Infra.Data.Repositories
{
    public class ProjetoRepository : IProjetoRepository
    {
        private readonly SigmaContext _dbContext;

        public ProjetoRepository(SigmaContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Inserir(Projeto entidade)
        {
           await _dbContext.Set<Projeto>().AddAsync(entidade);
           await _dbContext.SaveChangesAsync();
           return true;
        }

        public async Task<IEnumerable<Projeto>> ListarTodosAsync()
        {
            return await _dbContext.Set<Projeto>().ToListAsync();
        }


    }
}
