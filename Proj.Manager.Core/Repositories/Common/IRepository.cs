using Proj.Manager.Core.Entities;
using System.Linq.Expressions;

namespace Proj.Manager.Core.Repositories.Common
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        public void Atualizar(TEntity entity);
        public TEntity Buscar(Guid id);
        public TEntity Buscar(Expression<Func<TEntity, bool>> filter = null);
        public TEntity Criar(TEntity entity);
        public void Deletar(TEntity entity);
        public IEnumerable<TEntity> Listar();
        public IEnumerable<TEntity> Listar(Expression<Func<TEntity, bool>> filter = null);
    }
}
