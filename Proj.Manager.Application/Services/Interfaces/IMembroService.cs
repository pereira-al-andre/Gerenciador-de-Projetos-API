using Proj.Manager.Core.Entities;

namespace Proj.Manager.Application.Services.Interfaces
{
    public interface IMembroService
    {
        public List<Membro> ListaMembros();
        public Membro BuscarMembro(Guid id);
        public Membro CriarMembro(Membro membro);
        public List<Tarefa> ListarMembrosDaTarefa(Guid tarefaId);
        public void AtualizarMembro(Membro membro);
        public void AlterarCargo(Membro membro);
        public void AlterarSenha(Membro membro);
    }
}
