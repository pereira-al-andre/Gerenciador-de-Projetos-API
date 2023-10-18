using Proj.Manager.Application.Services.Interfaces;
using Proj.Manager.Core.Entities;
using Proj.Manager.Core.Enums;
using Proj.Manager.Core.Repositories;
using System.Linq;

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
            try
            {
                var tarefa = _repository.Buscar(tarefaId);

                if (tarefa == null)
                    throw new Exception("Tarefa não encontrada.");

                membros.ForEach(membro => tarefa.AdicionarMembros(membro));

                _repository.Atualizar(tarefa);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void AtualizarTarefa(Tarefa tarefa)
        {
            try
            {
                _repository.Atualizar(tarefa);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Tarefa BuscarTarefa(Guid id)
        {
            try
            {
                var tarefa = _repository.Buscar(id);

                if (tarefa == null)
                    throw new Exception("Tarefa não encontrada.");

                return tarefa;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void CacelarTarefa(Guid id)
        {
            try
            {
                var tarefa = _repository.Buscar(id);

                if (tarefa == null)
                    throw new Exception("Nenhuma tarefa foi encontrada para este parâmetro");

                tarefa.Cancelar();

                _repository.Atualizar(tarefa);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Tarefa CriarTarefa(Tarefa tarefa)
        {
            try
            {
                return _repository.Criar(tarefa);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeletarTarefa(Guid id)
        {
            try
            {
                var tarefa = _repository.Buscar(id);

                if (tarefa == null)
                    throw new Exception("Nenhuma tarefa foi encontrada para este parâmetro");

                tarefa.Deletar();

                _repository.Atualizar(tarefa);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void FinalizarTarefa(Guid id)
        {
            try
            {
                var tarefa = _repository.Buscar(id);

                if (tarefa == null)
                    throw new Exception("Nenhuma tarefa foi encontrada para este parâmetro");

                tarefa.Finalizar();

                _repository.Atualizar(tarefa);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Tarefa> ListarTarefas()
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

        public IEnumerable<Tarefa> ListarTarefasDoProjeto(Guid projetoId)
        {
            try
            {
                return _repository.Listar(x => x.ProjetoId == projetoId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Tarefa> ListaTarefasMembro(Guid membroId)
        {
            try
            {
                return _repository.Listar(x => x.Membros.Any(m => m.Id == membroId));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void MarcarTarefaEmAndamento(Guid id)
        {
            try
            {
                var tarefa = _repository.Buscar(id);

                if (tarefa == null)
                    throw new Exception("Nenhuma tarefa foi encontrada para este parâmetro");

                tarefa.MarcarEmAndamento();

                _repository.Atualizar(tarefa);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
