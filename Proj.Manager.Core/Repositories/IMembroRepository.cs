using Proj.Manager.Core.Entities;

namespace Proj.Manager.Core.Repositories
{
    public interface IMembroRepository
    {
        public List<Membro> Listar();
        public Membro Buscar(Guid id);
        public Membro Criar(Membro membro);
        public void Atualizar(Membro membro);
        public void Deletar(Membro membro);
    }
}
