using Sigma.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigma.Domain.Interfaces.Repositories
{
    public interface IProjetoRepository
    {
        Task<bool> Salvar(Projeto entidade);
        Task<IEnumerable<Projeto>> ListarTodosAsync();
        Task<List<Projeto>> Consultar(string nome);
        Task DeletarAsync(long id);
        Task<Projeto> ObterPorIdAsync(long Id);
    }
}
