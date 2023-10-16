using Proj.Manager.Core.Entities;

namespace Proj.Manager.Core.Repositories
{
    public interface ITarefaRepository
    {
        public List<Tarefa> Listar();
        public Tarefa Buscar(Guid id);
        public List<Tarefa> ListarPorMembro(Guid membroId);
        public List<Tarefa> ListarPorProjeto(Guid projetoId);
        public Tarefa Criar(Tarefa tarefa);
        public void Atualizar(Tarefa tarefa);
        public void Deletar(Tarefa tarefa);
    }
}
