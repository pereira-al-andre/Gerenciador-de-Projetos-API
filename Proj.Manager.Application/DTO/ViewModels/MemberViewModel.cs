using Proj.Manager.Core.Entities;
using Proj.Manager.Core.Enums;
using Proj.Manager.Core.Extensions;

namespace Proj.Manager.Application.DTO.ViewModels
{
    public class MemberTasks
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;

        public MemberTasks(Core.Entities.Task task)
        {
            this.Name = task.Name.Value;
            this.Id = task.Id;
        }
    }

    public class MemberProjects
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;

        public MemberProjects(Project project)
        {
            this.Name = project.Name.Value;
            this.Id = project.Id;
        }
    }

    public class MemberViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public Role Role { get; set; }
        public string Description { get { return this.Role.GetDescription();  } }

        public List<MemberTasks> Tasks { get; set; } = new();
        public List<MemberProjects> Projects { get; set; } = new();

        public MemberViewModel(Member member)
        {
            this.Id = member.Id;
            this.Name = member.Name.Value;
            this.Email = member.Email.Value;
            this.Role = member.Role;

            this.LoadProjects(member);
            this.LoadTasks(member);
        }

        public static List<MemberViewModel> MembersList(List<Member> members)
        {
            var memberViewModelList = new List<MemberViewModel>();
            members.ForEach(m => memberViewModelList.Add(new MemberViewModel(m)));

            return memberViewModelList;
        }

        private void LoadProjects(Member member) 
            => member.Projects.ForEach(project => this.Projects.Add(new MemberProjects(project)));

        private void LoadTasks(Member member)
            => member.Tasks.ForEach(task => this.Tasks.Add(new MemberTasks(task)));
    }
}
