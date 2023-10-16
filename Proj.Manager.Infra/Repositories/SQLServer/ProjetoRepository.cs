using Proj.Manager.Core.Entities;
using Proj.Manager.Core.Repositories;
using Proj.Manager.Infrastructure.Persistence.SQLServer;

namespace Proj.Manager.Infrastructure.Repositories.SQLServer
{
    public class ProjetoRepository : IProjetoRepository
    {
        private readonly SqlServerDBContext _dbContext;
        public ProjetoRepository(SqlServerDBContext context)
        {
            _dbContext = context;
        }

        public void Atualizar(Projeto tarefa)
        {
            _dbContext.Projeto.Update(tarefa);
            _dbContext.SaveChanges();
        }

        public Projeto Buscar(Guid id)
        {
            return _dbContext.Projeto.SingleOrDefault(x => x.Id == id);
        }

        public Projeto Criar(Projeto tarefa)
        {
            _dbContext.Projeto.Add(tarefa);
            _dbContext.SaveChanges();

            return tarefa;
        }

        public void Deletar(Projeto tarefa)
        {
            _dbContext.Projeto.Remove(tarefa);
            _dbContext.SaveChanges();
        }

        public List<Projeto> Listar()
        {
            return _dbContext.Projeto.ToList();
        }

        public List<Projeto> ListarPorMembro(Guid membroId)
        {
            return _dbContext.Projeto.Where(x => x.GerenteId == membroId).ToList();
        }
    }
}
