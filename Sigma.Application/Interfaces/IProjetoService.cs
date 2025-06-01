using Sigma.Application.Dtos;
using Sigma.Domain.Dtos;

namespace Sigma.Application.Interfaces
{
    public interface IProjetoService
    {
        Task<bool> Inserir(ProjetoNovoDto model);

        Task<List<ProjetoDto>> Listar();
        Task Editar(ProjetoDto model);

        Task<string> LoginAsync(string username, string password);
        Task DeletarPorId(long id);

        string GerarToken(string username);
        Task<List<ProjetoConsultaDto>> ConsultarAsync(string nome);
    }
}
