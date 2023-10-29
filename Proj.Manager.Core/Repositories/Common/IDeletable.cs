using Proj.Manager.Core.Primitives;

namespace Proj.Manager.Core.Repositories.Common
{
    public interface IDeletable<TEntity> where TEntity : Entity
    {
        public void Delete(TEntity entity);
    }
}
