using Proj.Manager.Core.Entities;

namespace Proj.Manager.Application.Services.Interfaces
{
    public interface ITarefaService
    {
        public List<Tarefa> ListaTarefasMembro(Guid membroId);
        public List<Tarefa> ListarTarefasDoProjeto(Guid projetoId);
        public List<Tarefa> ListarTarefas();
        public Tarefa BuscarTarefa(Guid id);
        public Tarefa CriarTarefa(Tarefa tarefa);
        public void AtualizarTarefa(Tarefa tarefa);
        public void DeletarTarefa(Guid id);
        public void CacelarTarefa(Guid id);
        public void FinalizarTarefa(Guid id);
        public void MarcarTarefaEmAndamento(Guid id);
        public void AdicionarMembros(List<Membro> membros, Guid tarefaId);
    }
}
