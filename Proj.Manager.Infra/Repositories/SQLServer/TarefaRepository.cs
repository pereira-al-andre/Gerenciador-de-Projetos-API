using Microsoft.EntityFrameworkCore;
using Proj.Manager.Core.Entities;
using Proj.Manager.Core.Repositories;
using Proj.Manager.Infrastructure.Persistence.SQLServer;

namespace Proj.Manager.Infrastructure.Repositories.SQLServer
{
    public class TarefaRepository : ITarefaRepository
    {
        private readonly SqlServerDBContext _dbContext;
        public TarefaRepository(SqlServerDBContext context)
        {
            _dbContext = context;
        }

        public void Atualizar(Tarefa tarefa)
        {
            _dbContext.Tarefa              
                .Update(tarefa);

            _dbContext.SaveChanges();
        }

        public Tarefa Buscar(Guid id)
        {
            return _dbContext.Tarefa
                    .Include("Membros")
                    .Include("Projeto")
                    .SingleOrDefault(x => x.Id == id);
        }

        public List<Tarefa> ListarPorMembro(Guid membroId)
        {
            return _dbContext.Tarefa.Where(x => x.Membros.Any(x => x.Id == membroId)).ToList();
        }

        public Tarefa Criar(Tarefa tarefa)
        {
            _dbContext.Tarefa.Add(tarefa);
            _dbContext.SaveChanges();

            return tarefa;
        }

        public void Deletar(Tarefa tarefa)
        {
            _dbContext.Tarefa.Remove(tarefa);
            _dbContext.SaveChanges();
        }

        public List<Tarefa> Listar()
        {
            return _dbContext.Tarefa.ToList();
        }

        public List<Tarefa> ListarPorProjeto(Guid projetoId)
        {
            return _dbContext.Tarefa.Where(x => x.ProjetoId == projetoId).ToList();
        }
    }
}
