using Proj.Manager.Core.Entities;

namespace Proj.Manager.Application.Services.Interfaces
{
    public interface ITaskService
    {
        public IEnumerable<Core.Entities.Task> MembersList(Guid memberId);
        public IEnumerable<Core.Entities.Task> ListProjectTasks(Guid projectId);
        public IEnumerable<Core.Entities.Task> All();
        public Core.Entities.Task Find(Guid id);
        public Core.Entities.Task Create(Core.Entities.Task task);
        public void UpdateTask(Core.Entities.Task task);
        public void Delete(Guid id);
        public void Cancel(Guid id);
        public void Complete(Guid id);
        public void Start(Guid id);
        public void AddMembers(List<Member> members, Guid taskId);
    }
}
