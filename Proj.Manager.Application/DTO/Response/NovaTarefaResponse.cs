using Proj.Manager.Core.Entities;
using Proj.Manager.Core.Extensions;

namespace Proj.Manager.Application.DTO.Response
{
    public class NovaTarefaResponse
    {
        public Guid Id { get; private set; }
        public Guid ProjetoId { get; private set; }
        public string Nome { get; private set; } = null!;
        public string Descricao { get; private set; } = null!;
        public DateTime DataInicio { get; private set; }
        public DateTime DataPrazo { get; private set; }
        public DateTime? DataTermino { get; private set; } = null;
        public string Status { get; private set; }

        public NovaTarefaResponse(Tarefa tarefa)
        {
            Id = tarefa.Id;
            ProjetoId = tarefa.ProjetoId;
            Nome = tarefa.Nome;
            Descricao = tarefa.Descricao;
            DataInicio = tarefa.DataInicio;
            DataPrazo = tarefa.DataPrazo;
            DataTermino = tarefa.DataTermino;
            Status = tarefa.Status.RetornarDescricao();
        }
    }
}
