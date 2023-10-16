using Proj.Manager.Application.Services.Interfaces;
using Proj.Manager.Core.Entities;
using Proj.Manager.Core.Repositories;

namespace Proj.Manager.Application.Services
{
    public class ProjetoService : IProjetoService
    {
        private readonly IProjetoRepository _repository;
        private readonly ITarefaRepository _tarefaRepository;
        public ProjetoService(
            IProjetoRepository projetoRepository,
            ITarefaRepository tarefaRepository)
        {
            _repository = projetoRepository;
            _tarefaRepository = tarefaRepository;

        }

        public void AtualizarProjeto(Projeto projeto)
        {
            _repository.Atualizar(projeto);
        }

        public Projeto BuscarProjeto(Guid id)
        {
            return _repository.Buscar(id);
        }

        public void CancelarProjeto(Guid id)
        {
            var model = _repository.Buscar(id);
            model.Cancelar();

            _repository.Atualizar(model);
        }

        public Projeto CriarProjeto(Projeto projeto)
        {
            return _repository.Criar(projeto);
        }

        public void DeletarProjeto(Guid id)
        {
            var model = _repository.Buscar(id);
            model.Deletar();

            _repository.Atualizar(model);
        }

        public void FinalizarProjeto(Guid id)
        {
            var model = _repository.Buscar(id);
            model.Finalizar();

            _repository.Atualizar(model);
        }

        public List<Projeto> ListarProjetos()
        {
            return _repository.Listar();
        }

        public List<Projeto> ListarProjetosMembro(Guid membroId)
        {
            return _repository.ListarPorMembro(membroId);
        }

        public void MarcarProjetoEmAndamento(Guid id)
        {
            var model = _repository.Buscar(id);
            model.MarcarEmAndamento();

            _repository.Atualizar(model);
        }

        public void RemoverTarefa(Guid tarefaId, Guid projetoId)
        {
            var projeto = _repository.Buscar(projetoId);
            var tarefa = _tarefaRepository.Buscar(tarefaId);
            projeto.RemoverTarefa(tarefa);

            _repository.Atualizar(projeto);
        }
    }
}
