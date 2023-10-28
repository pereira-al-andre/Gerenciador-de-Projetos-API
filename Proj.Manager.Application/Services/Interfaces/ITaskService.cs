using Proj.Manager.Application.DTO.RequestModels.Task;
using Proj.Manager.Application.DTO.ViewModels;
using Proj.Manager.Core.Entities;

namespace Proj.Manager.Application.Services.Interfaces
{
    public interface ITaskService
    {
        public List<MemberViewModel> ListTaskMembers(Guid taskId);
        public List<TaskViewModel> ListProjectTasks(Guid projectId);
        public List<TaskViewModel> All();
        public TaskViewModel Find(Guid id);
        public void Update(UpdateTaskRequest task);
        public void Delete(Guid id);
        public void Cancel(Guid id);
        public void Complete(Guid id);
        public void Start(Guid id);
        public void AddMembers(Guid[] members, Guid taskId);
    }
}
