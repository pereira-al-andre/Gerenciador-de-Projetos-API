using Microsoft.EntityFrameworkCore;
using Proj.Manager.Core.Primitives;
using Proj.Manager.Core.Repositories.Common;
using Proj.Manager.Infrastructure.Persistence.SQLServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Proj.Manager.Infrastructure.Repositories.SQLServer.Common
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected readonly SqlServerDBContext _dbContext;
        protected readonly DbSet<TEntity> _DbSet;

        public Repository(SqlServerDBContext context)
        {
            _dbContext = context;
            _DbSet = context.Set<TEntity>();
        }

        public void Update(TEntity entity)
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

        public TEntity? Find(Guid id)
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

        public TEntity? Find(Expression<Func<TEntity, bool>> filter)
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

        public TEntity? Find(Guid id, string includes)
        {
            try
            {
                return _DbSet.Include(includes).SingleOrDefault(x => x.Id == id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public TEntity? Find(Expression<Func<TEntity, bool>> filter, string includes)
        {
            try
            {
                return _DbSet.Include(includes).SingleOrDefault(filter);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public TEntity Create(TEntity entity)
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

        public IEnumerable<TEntity> All()
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

        public IEnumerable<TEntity> All(Expression<Func<TEntity, bool>> filter)
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
