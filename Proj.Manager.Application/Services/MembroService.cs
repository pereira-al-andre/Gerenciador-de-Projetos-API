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
            _repository.Atualizar(membro);
        }

        public void AlterarSenha(Membro membro)
        {
            _repository.Atualizar(membro);
        }

        public void AtualizarMembro(Membro membro)
        {
            _repository.Atualizar(membro);
        }

        public Membro BuscarMembro(Guid id)
        {
            return _repository.Buscar(id);
        }

        public Membro CriarMembro(Membro membro)
        {
            return _repository.Criar(membro);
        }

        public List<Membro> ListaMembros()
        {
            return _repository.Listar();
        }

        public List<Tarefa> ListarMembrosDaTarefa(Guid tarefaId)
        {
            return _tarefaRepository.ListarPorMembro(tarefaId);
        }
    }
}
