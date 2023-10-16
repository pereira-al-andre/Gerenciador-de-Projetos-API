using Proj.Manager.Core.Entities;
using Proj.Manager.Core.Extensions;

namespace Proj.Manager.Application.DTO.Response
{
    public class NovoProjetoResponse
    {
        public Guid Id { get; set; }
        public Guid GerenteId { get; set; }
        public string Nome { get; set; } = null!;
        public string Descricao { get; set; } = null!;
        public DateTime DataInicio { get; set; }
        public DateTime DataPrazo { get; set; }
        public DateTime? DataTermino { get; set; } = null;
        public string Status { get; set; }

        public NovoProjetoResponse(Projeto projeto)
        {
            Id = projeto.Id;
            GerenteId = projeto.GerenteId;
            Nome = projeto.Nome;
            Descricao = projeto.Descricao;
            DataInicio = projeto.DataInicio;
            DataPrazo = projeto.DataPrazo;
            DataTermino = projeto.DataTermino;
            Status = projeto.Status.RetornarDescricao();
        }
    }
}
