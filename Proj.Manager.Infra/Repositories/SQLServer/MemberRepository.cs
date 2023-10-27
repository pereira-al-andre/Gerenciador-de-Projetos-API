using Microsoft.EntityFrameworkCore;
using Proj.Manager.Core.Entities;
using Proj.Manager.Core.Repositories;
using Proj.Manager.Infrastructure.Persistence.SQLServer;
using Proj.Manager.Infrastructure.Repositories.SQLServer.Common;

namespace Proj.Manager.Infrastructure.Repositories.SQLServer
{
    public class MemberRepository : Repository<Member>, IMemberRepositoy
    {
        public MemberRepository(SqlServerDBContext context) : base(context)
        {
        }
    }
}
