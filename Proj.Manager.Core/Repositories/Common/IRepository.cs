using Proj.Manager.Core.Primitives;
using System.Linq.Expressions;

namespace Proj.Manager.Core.Repositories.Common
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        public void Update(TEntity entity);
        public TEntity? Find(Guid id);
        public TEntity? Find(Expression<Func<TEntity, bool>> filter);
        public TEntity? Find(Guid id, string includes);
        public TEntity? Find(Expression<Func<TEntity, bool>> filter, string includes);
        public TEntity Create(TEntity entity);
        public IEnumerable<TEntity> All();
        public IEnumerable<TEntity> All(Expression<Func<TEntity, bool>> filter);
    }
}
