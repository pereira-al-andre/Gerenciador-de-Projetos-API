using Proj.Manager.Application.Exceptions;
using Proj.Manager.Application.Services.Interfaces;
using Proj.Manager.Core.Entities;
using Proj.Manager.Core.Repositories;

namespace Proj.Manager.Application.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _repository;
        private readonly ITaskRepository _taskRepository;
        public ProjectService(
            IProjectRepository projectRepository,
            ITaskRepository taskRepository)
        {
            _repository = projectRepository;
            _taskRepository = taskRepository;

        }

        public void Update(Project project)
        {
            try
            {
                _repository.Update(project);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Project Find(Guid id)
        {
            try
            {
                var project = _repository.Find(id);

                if (project == null)
                    throw new ProjectNotFoundException("Project não encontrado.");

                return project;
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
                var model = _repository.Find(id);

                if (model == null)
                    throw new ProjectNotFoundException("Project não encontrado");

                model.Cancel();

                _repository.Update(model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Project Create(Project project)
        {
            try
            {
                return _repository.Create(project);
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
                var model = _repository.Find(id);

                if (model == null)
                    throw new ProjectNotFoundException("Project não encontrado");

                model.Delete();

                _repository.Update(model);
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
                var model = _repository.Find(id);

                if (model == null)
                    throw new ProjectNotFoundException("Project não encontrado");

                model.Finish();

                _repository.Update(model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Project> All()
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

        public IEnumerable<Project> ListMemberProjects(Guid memberId)
        {
            try
            {
                return _repository.All(x => x.ManagerId == memberId);
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
                var model = _repository.Find(id);

                if (model == null)
                    throw new ProjectNotFoundException("Project não encontrado");

                model.Start();

                _repository.Update(model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void RemoveTask(Guid taskId, Guid projectId)
        {
            try
            {
                var project = _repository.Find(projectId);

                if (project == null)
                    throw new ProjectNotFoundException("Project não encontrado");

                var task = _taskRepository.Find(taskId);

                if (task == null)
                    throw new TaskNotFoundException("Task não encontrado");

                project.RemoveTask(task);

                _repository.Update(project);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
