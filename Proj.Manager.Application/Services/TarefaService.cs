using Proj.Manager.Application.Services.Interfaces;
using Proj.Manager.Core.Entities;
using Proj.Manager.Core.Repositories;

namespace Proj.Manager.Application.Services
{
    public class TarefaService : ITarefaService
    {
        private readonly ITarefaRepository _repository;
        public TarefaService(ITarefaRepository tarefaRepository)
        {
            _repository = tarefaRepository;
        }

        public void AdicionarMembros(List<Membro> membros, Guid tarefaId)
        {
            var tarefa = _repository.Buscar(tarefaId);

            membros.ForEach(membro => tarefa.AdicionarMembros(membro));

            _repository.Atualizar(tarefa);
        }

        public void AtualizarTarefa(Tarefa tarefa)
        {
            _repository.Atualizar(tarefa);
        }

        public Tarefa BuscarTarefa(Guid id)
        {
            return _repository.Buscar(id);
        }

        public void CacelarTarefa(Guid id)
        {
            var tarefa = _repository.Buscar(id);
            tarefa.Cancelar();
            _repository.Atualizar(tarefa);
        }

        public Tarefa CriarTarefa(Tarefa tarefa)
        {
            return _repository.Criar(tarefa);
        }

        public void DeletarTarefa(Guid id)
        {
            var tarefa = _repository.Buscar(id);
            tarefa.Deletar();
            _repository.Atualizar(tarefa);
        }

        public void FinalizarTarefa(Guid id)
        {
            var tarefa = _repository.Buscar(id);
            tarefa.Finalizar();
            _repository.Atualizar(tarefa);
        }

        public List<Tarefa> ListarTarefas()
        {
            return _repository.Listar();
        }

        public List<Tarefa> ListarTarefasDoProjeto(Guid projetoId)
        {
            return _repository.ListarPorProjeto(projetoId);
        }

        public List<Tarefa> ListaTarefasMembro(Guid membroId)
        {
            return _repository.ListarPorMembro(membroId);
        }

        public void MarcarTarefaEmAndamento(Guid id)
        {
            var tarefa = _repository.Buscar(id);
            tarefa.MarcarEmAndamento();
            _repository.Atualizar(tarefa);
        }
    }
}
