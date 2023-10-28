using Proj.Manager.Core.Entities;
using Proj.Manager.Core.Repositories.Common;

namespace Proj.Manager.Core.Repositories
{
    public interface IMemberRepositoy : IRepository<Member>, IDeletable<Member>
    { }
}
