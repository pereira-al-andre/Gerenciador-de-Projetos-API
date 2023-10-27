using Proj.Manager.Core.Entities;

namespace Proj.Manager.Application.Services.Interfaces
{
    public interface IProjectService
    {
        public IEnumerable<Project> ListMemberProjects(Guid memberId);
        public IEnumerable<Project> All();
        public Project Find(Guid id);
        public Project Create(Project project);
        public void Delete(Guid id);
        public void Complete(Guid id);
        public void Start(Guid id);
        public void Cancel(Guid id);
        public void Update(Project project);
        public void RemoveTask(Guid taskId, Guid projectId);
    }
}
