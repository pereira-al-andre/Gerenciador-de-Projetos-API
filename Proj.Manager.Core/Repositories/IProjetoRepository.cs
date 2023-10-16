using Proj.Manager.Core.Entities;

namespace Proj.Manager.Core.Repositories
{
    public interface IProjetoRepository
    {
        public List<Projeto> Listar();
        public Projeto Buscar(Guid id);
        public List<Projeto> ListarPorMembro(Guid membroId);
        public Projeto Criar(Projeto tarefa);
        public void Atualizar(Projeto tarefa);
        public void Deletar(Projeto tarefa);
    }
}
