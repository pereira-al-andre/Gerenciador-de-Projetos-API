using Proj.Manager.Application.DTO.RequestModels.Member;
using Proj.Manager.Application.DTO.ViewModels;
using Proj.Manager.Core.Entities;

namespace Proj.Manager.Application.Services.Interfaces
{
    public interface IMemberService
    {
        public List<MemberViewModel> All();
        public List<TaskViewModel> ListMemberTasks(Guid memberId);
        public List<ProjectViewModel> ListMemberProjects(Guid memberId);
        public MemberViewModel Find(Guid id);
        public MemberViewModel Create(CreateMemberRequest request);
        public void Update(UpdateMemberRequest request);
        public void UpdateRole(UpdateRoleRequest member);
        public void UpdatePassword(UpdatePasswordRequest member);
    }
}
