using Microsoft.EntityFrameworkCore;
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

        public async Task<bool> Salvar(Projeto entidade)
        {
            if (entidade.DataInicio == default)
            {
                entidade.DataInicio = DateTime.UtcNow;
            }
            if (entidade.Id != 0)
                 _dbContext.Projetos.Update(entidade);
            else
            {
                await _dbContext.Set<Projeto>().AddAsync(entidade);
            }
           await _dbContext.SaveChangesAsync();
           return true;
        }

        public async Task<IEnumerable<Projeto>> ListarTodosAsync()
        {
            return await _dbContext.Set<Projeto>().ToListAsync();
        }
        public async Task<Projeto> ObterPorId(long Id)
        {
            return await _dbContext.Projetos.FirstOrDefaultAsync(c => c.Id == Id);

        }
        
        public async Task<List<Projeto>> Consultar(string nome)
        {
            return await _dbContext.Projetos.Where(c => c.Nome.Contains(nome)).ToListAsync();
        }

        public async Task DeletarAsync(long id)
        {
            await _dbContext.Projetos.Where(c => c.Id == id).ExecuteDeleteAsync();
        }

    }
}
