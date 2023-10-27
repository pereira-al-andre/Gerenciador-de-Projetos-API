using Proj.Manager.Application.Exceptions;
using Proj.Manager.Application.Services.Interfaces;
using Proj.Manager.Core.Entities;
using Proj.Manager.Core.Enums;
using Proj.Manager.Core.Repositories;
using System.Linq;

namespace Proj.Manager.Application.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _repository;
        public TaskService(ITaskRepository taskRepository)
        {
            _repository = taskRepository;
        }

        public void AddMembers(List<Member> members, Guid taskId)
        {
            try
            {
                var task = _repository.Find(taskId);

                if (task == null)
                    throw new TaskNotFoundException("Task não encontrada.");

                members.ForEach(member => task.AddMember(member));

                _repository.Update(task);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateTask(Core.Entities.Task task)
        {
            try
            {
                _repository.Update(task);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Core.Entities.Task Find(Guid id)
        {
            try
            {
                var task = _repository.Find(id);

                if (task == null)
                    throw new TaskNotFoundException("Task não encontrada.");

                return task;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Cancel(Guid id)
        {
            try
            {
                var task = _repository.Find(id);

                if (task == null)
                    throw new TaskNotFoundException("Nenhuma task foi encontrada para este parâmetro");

                task.Cancel();

                _repository.Update(task);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Core.Entities.Task Create(Core.Entities.Task task)
        {
            try
            {
                return _repository.Create(task);
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
                var task = _repository.Find(id);

                if (task == null)
                    throw new TaskNotFoundException("Nenhuma task foi encontrada para este parâmetro");

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
                var task = _repository.Find(id);

                if (task == null)
                    throw new TaskNotFoundException("Nenhuma task foi encontrada para este parâmetro");

                task.Complete();

                _repository.Update(task);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Core.Entities.Task> All()
        {
            try
            {
                return _repository.All();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Core.Entities.Task> ListProjectTasks(Guid projectId)
        {
            try
            {
                return _repository.All(x => x.ProjectId == projectId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Core.Entities.Task> MembersList(Guid memberId)
        {
            try
            {
                return _repository.All(x => x.Members.Any(m => m.Id == memberId));
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
                var task = _repository.Find(id);

                if (task == null)
                    throw new TaskNotFoundException("Nenhuma task foi encontrada para este parâmetro");

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
