using Microsoft.EntityFrameworkCore;
using Proj.Manager.Core.Entities;
using Proj.Manager.Core.Repositories.Common;
using Proj.Manager.Infrastructure.Exceptions;
using Proj.Manager.Infrastructure.Persistence.SQLServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Proj.Manager.Infrastructure.Repositories.SQLServer.Common
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly SqlServerDBContext _dbContext;
        private readonly DbSet<TEntity> _DbSet;
        public Repository(SqlServerDBContext context)
        {
            _dbContext = context;
            _DbSet = context.Set<TEntity>();
        }

        public void Atualizar(TEntity entity)
        {
            try
            {
                _DbSet.Update(entity);
                _dbContext.SaveChanges();

            }
            catch (Exception)
            {
                throw;
            }
        }

        public TEntity Buscar(Guid id)
        {
            try
            {
                return _DbSet.SingleOrDefault(x => x.Id == id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public TEntity Buscar(Expression<Func<TEntity, bool>> filter = null)
        {
            try
            {
                return _DbSet.SingleOrDefault(filter);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public TEntity Criar(TEntity entity)
        {
            try
            {
                _DbSet.Add(entity);
                _dbContext.SaveChanges();

                return entity;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Deletar(TEntity entity)
        {
            try
            {
                _DbSet.Remove(entity);
                _dbContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<TEntity> Listar()
        {
            try
            {
                return _DbSet.AsEnumerable();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<TEntity> Listar(Expression<Func<TEntity, bool>> filter = null)
        {
            try
            {
                return _DbSet.Where(filter);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
