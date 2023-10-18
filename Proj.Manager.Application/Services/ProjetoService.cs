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
            try
            {
                _repository.Atualizar(projeto);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Projeto BuscarProjeto(Guid id)
        {
            try
            {
                var projeto = _repository.Buscar(id);

                if (projeto == null)
                    throw new Exception("Projeto não encontrado.");

                return projeto;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void CancelarProjeto(Guid id)
        {
            try
            {
                var model = _repository.Buscar(id);

                if (model == null)
                    throw new Exception("Projeto não encontrado");

                model.Cancelar();

                _repository.Atualizar(model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Projeto CriarProjeto(Projeto projeto)
        {
            try
            {
                return _repository.Criar(projeto);
            }
            catch (Exception)
            {
                throw;
            }            
        }

        public void DeletarProjeto(Guid id)
        {
            try
            {
                var model = _repository.Buscar(id);

                if (model == null)
                    throw new Exception("Projeto não encontrado");

                model.Deletar();

                _repository.Atualizar(model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void FinalizarProjeto(Guid id)
        {
            try
            {
                var model = _repository.Buscar(id);

                if (model == null)
                    throw new Exception("Projeto não encontrado");

                model.Finalizar();

                _repository.Atualizar(model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Projeto> ListarProjetos()
        {
            try
            {
                return _repository.Listar();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Projeto> ListarProjetosMembro(Guid membroId)
        {
            try
            {
                return _repository.Listar(x => x.GerenteId == membroId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void MarcarProjetoEmAndamento(Guid id)
        {
            try
            {
                var model = _repository.Buscar(id);

                if (model == null)
                    throw new Exception("Projeto não encontrado");

                model.MarcarEmAndamento();

                _repository.Atualizar(model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void RemoverTarefa(Guid tarefaId, Guid projetoId)
        {
            try
            {
                var projeto = _repository.Buscar(projetoId);

                if (projeto == null)
                    throw new Exception("Projeto não encontrado");

                var tarefa = _tarefaRepository.Buscar(tarefaId);

                if (tarefa == null)
                    throw new Exception("Tarefa não encontrado");

                projeto.RemoverTarefa(tarefa);

                _repository.Atualizar(projeto);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
