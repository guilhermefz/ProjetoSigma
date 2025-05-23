using Sigma.Application.Dtos;
using Sigma.Domain.Dtos;

namespace Sigma.Application.Interfaces
{
    public interface IProjetoService
    {
        Task<bool> Inserir(ProjetoNovoDto model);

        Task<List<ProjetoDto>> Listar();

        Task<string> LoginAsync(string username, string password);
    }
}
