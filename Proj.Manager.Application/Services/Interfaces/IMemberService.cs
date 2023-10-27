using Proj.Manager.Core.Entities;

namespace Proj.Manager.Application.Services.Interfaces
{
    public interface IMemberService
    {
        public IEnumerable<Member> All();
        public Member Find(Guid id);
        public Member Create(Member member);
        public List<Member> ListTaskMembers(Guid taskId);
        public void Update(Member member);
        public void UpdateRole(Member member);
        public void UpdatePassword(Member member);
    }
}
