using Sigma.Domain.Enums;

namespace Sigma.Domain.Dtos
{
    public class ProjetoNovoDto
    {
        public string? Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime PrevisaoTermino { get; set; }
        public decimal Orcamento { get; set; }
        public ClassificacaoRisco Classificacao { get; set; }
        public StatusProjeto Status { get; set; }
    }
}
