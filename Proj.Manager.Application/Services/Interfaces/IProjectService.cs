using Proj.Manager.Application.DTO.RequestModels.Project;
using Proj.Manager.Application.DTO.RequestModels.Task;
using Proj.Manager.Application.DTO.ViewModels;
using Proj.Manager.Core.Entities;

namespace Proj.Manager.Application.Services.Interfaces
{
    public interface IProjectService
    {
        public List<ProjectViewModel> ListMemberProjects(Guid memberId);
        List<ProjectViewModel> All();
        List<TaskViewModel> ListProjectTasks(Guid projectId);
        ProjectViewModel Find(Guid id);
        ProjectViewModel Create(CreateProjectRequest request);
        void Delete(Guid id);
        void Complete(Guid id);
        void Cancel(Guid id);
        void Update(UpdateProjectRequest request);
        void AddTask(CreateTaskRequest request, Guid projectId);
        void RemoveTask(Guid taskId, Guid projectId);
    }
}
