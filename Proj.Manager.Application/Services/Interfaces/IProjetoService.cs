using Proj.Manager.Core.Entities;

namespace Proj.Manager.Application.Services.Interfaces
{
    public interface IProjetoService
    {
        public List<Projeto> ListarProjetosMembro(Guid membroId);
        public List<Projeto> ListarProjetos();
        public Projeto BuscarProjeto(Guid id);
        public Projeto CriarProjeto(Projeto projeto);
        public void DeletarProjeto(Guid id);
        public void FinalizarProjeto(Guid id);
        public void MarcarProjetoEmAndamento(Guid id);
        public void CancelarProjeto(Guid id);
        public void AtualizarProjeto(Projeto projeto);
        public void RemoverTarefa(Guid tarefaId, Guid projetoId);
    }
}
