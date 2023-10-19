using Proj.Manager.Application.Exceptions;
using Proj.Manager.Application.Services.Interfaces;
using Proj.Manager.Core.Entities;
using Proj.Manager.Core.Repositories;
using System;

namespace Proj.Manager.Application.Services
{
    public class MembroService : IMembroService
    {
        private readonly IMembroRepository _repository;
        private readonly ITarefaRepository _tarefaRepository;
        public MembroService(
            IMembroRepository membroRepository,
            ITarefaRepository tarefaRepository)
        {
            _repository = membroRepository;
            _tarefaRepository = tarefaRepository;
        }

        public void AlterarCargo(Membro membro)
        {
            try
            {
                _repository.Atualizar(membro);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void AlterarSenha(Membro membro)
        {
            try
            {
                _repository.Atualizar(membro);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void AtualizarMembro(Membro membro)
        {
            try
            {
                _repository.Atualizar(membro);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Membro BuscarMembro(Guid id)
        {
            try
            {
                var membro = _repository.Buscar(id);

                if (membro == null)
                    throw new MembroNaoEncontratoException("Membro não encontrado.");

                return membro;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Membro CriarMembro(Membro membro)
        {
            try
            {
                return _repository.Criar(membro);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Membro> ListaMembros()
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

        public List<Membro> ListarMembrosDaTarefa(Guid tarefaId)
        {
            try
            {
                var tarefa = _tarefaRepository.Buscar(tarefaId);

                if (tarefa == null)
                    throw new TarefaNaoEncontradaException("Tarefa não encontrada");

                return tarefa.Membros;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
