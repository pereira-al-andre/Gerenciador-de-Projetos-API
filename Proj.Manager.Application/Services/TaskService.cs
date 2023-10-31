using Proj.Manager.Application.DTO.RequestModels.Task;
using Proj.Manager.Application.DTO.ViewModels;
using Proj.Manager.Application.Exceptions;
using Proj.Manager.Application.Services.Interfaces;
using Proj.Manager.Core.Entities;
using Proj.Manager.Core.Enums;
using Proj.Manager.Core.Repositories;
using Proj.Manager.Core.ValueObjects;
using System.Linq;
using System.Threading.Tasks;

namespace Proj.Manager.Application.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _repository;
        private readonly IMemberRepository _memberRepositoy;
        public TaskService(
            ITaskRepository taskRepository, 
            IMemberRepository memberRepositoy)
        {
            _repository = taskRepository;
            _memberRepositoy = memberRepositoy;
        }

        public TaskViewModel Find(Guid id)
        {
            try
            {
                var task = _repository.Find(id) ?? throw new TaskNotFoundException("Task não encontrada.");

                return new TaskViewModel(task);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<TaskViewModel> All()
        {
            try
            {
                var tasks = _repository.All();

                return TaskViewModel.TasksList(tasks.ToList());
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<TaskViewModel> ListProjectTasks(Guid projectId)
        {
            try
            {
                var tasks = _repository.All(x => x.ProjectId == projectId);

                return TaskViewModel.TasksList(tasks.ToList());
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<MemberViewModel> ListTaskMembers(Guid taskId)
        {
            try
            {
                var task = _repository.Find(taskId) ?? throw new Exception("Task not found");
                var members = task.Members.OrderBy(x => x.Name);
                return MemberViewModel.MembersList(members.ToList());
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void AddMembers(Guid[] members, Guid taskId)
        {
            try
            {
                var task = _repository.Find(taskId) ?? throw new TaskNotFoundException("Task not found.");

                var membersList = _memberRepositoy.All(x => members.Contains(x.Id)).ToList();

                membersList.ForEach(task.AddMember);

                _repository.Update(task);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void RemoveMember(Guid memberId, Guid taskId)
        {
            try
            {
                var task = _repository.Find(taskId) ?? throw new TaskNotFoundException("Task not found.");
                var memeber = _memberRepositoy.Find(memberId) ?? throw new MemberNotFoundException("Member not found.");

                task.RemoveMember(memeber);

                _repository.Update(task);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void Update(UpdateTaskRequest request)
        {
            try
            {
                var task = _repository.Find(request.Id) ?? throw new Exception("Task not found.");

                task.Update(new Name(request.Name), new Description(request.Description));

                _repository.Update(task);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void Delete(Guid id)
        {
            try
            {
                var task = _repository.Find(id) ?? throw new TaskNotFoundException("Task not found.");

                task.Delete();

                _repository.Update(task);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void Complete(Guid id)
        {
            try
            {
                var task = _repository.Find(id) ?? throw new TaskNotFoundException("Task not found.");

                task.Complete();

                _repository.Update(task);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void Start(Guid id)
        {
            try
            {
                var task = _repository.Find(id) ?? throw new TaskNotFoundException("Task not found.");

                task.Start();

                _repository.Update(task);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
