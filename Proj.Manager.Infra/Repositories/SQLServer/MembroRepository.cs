using Microsoft.EntityFrameworkCore;
using Proj.Manager.Core.Entities;
using Proj.Manager.Core.Repositories;
using Proj.Manager.Infrastructure.Persistence.SQLServer;
using System;

namespace Proj.Manager.Infrastructure.Repositories.SQLServer
{
    public class MembroRepository : IMembroRepository
    {
        private readonly SqlServerDBContext _dbContext;
        public MembroRepository(SqlServerDBContext context)
        {
            _dbContext = context;
        }

        public void Atualizar(Membro membro)
        {
            _dbContext.Membro.Update(membro);
            _dbContext.SaveChanges();
        }

        public Membro Buscar(Guid id)
        {
            return _dbContext.Membro
                    .Include("Tarefas")
                    .Include("Projetos")
                    .SingleOrDefault(x => x.Id == id);
        }

        public Membro Criar(Membro membro)
        {
            _dbContext.Membro.Add(membro);
            _dbContext.SaveChanges();

            return membro;
        }

        public void Deletar(Membro membro)
        {
            _dbContext.Membro.Remove(membro);
            _dbContext.SaveChanges();
        }

        public List<Membro> Listar()
        {
            return _dbContext.Membro.ToList();
        }
    }
}
