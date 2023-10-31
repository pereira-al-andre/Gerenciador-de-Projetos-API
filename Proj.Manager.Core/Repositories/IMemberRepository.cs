using Proj.Manager.Core.Entities;
using Proj.Manager.Core.Repositories.Common;

namespace Proj.Manager.Core.Repositories
{
    public interface IMemberRepository : IRepository<Member>, IDeletable<Member>
    { }
}
