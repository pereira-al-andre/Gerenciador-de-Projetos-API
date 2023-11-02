using Proj.Manager.Application.DTO.RequestModels.Project;
using Proj.Manager.Application.DTO.RequestModels.Task;
using Proj.Manager.Application.DTO.ViewModels;
using Proj.Manager.Application.Enums;
using Proj.Manager.Application.Exceptions.Common;
using Proj.Manager.Application.Services.Interfaces;
using Proj.Manager.Core.Entities;
using Proj.Manager.Core.Repositories;
using Proj.Manager.Core.ValueObjects;

namespace Proj.Manager.Application.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _repository;
        private readonly IMemberRepository _memberRepository;
        public ProjectService(
            IProjectRepository projectRepository,
            IMemberRepository memberRepository)
        {
            _repository = projectRepository;
            _memberRepository = memberRepository;
        }

        public void Update(UpdateProjectRequest request)
        {
            try
            {
                var project = _repository.Find(request.Id) ?? throw new ApplicationLayerException(ApplicationExceptionType.ProjectNotFound);

                project.Update(new Name(request.Name), new Description(request.Description));

                _repository.Update(project);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public ProjectViewModel Find(Guid id)
        {
            try
            {
                var project = _repository.Find(id) ?? throw new ApplicationLayerException(ApplicationExceptionType.ProjectNotFound);

                return new ProjectViewModel(project);
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
                var model = _repository.Find(id, "Tasks") ?? throw new ApplicationLayerException(ApplicationExceptionType.ProjectNotFound);

                model.Cancel();

                _repository.Update(model);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public ProjectViewModel Create(CreateProjectRequest request)
        {
            try
            {
                var manager = _memberRepository.Find(request.ManagerId) ?? throw new ApplicationLayerException(ApplicationExceptionType.MemberNotFound);

                var project = new Project(
                    manager,
                    new Name(request.Name),
                    new Description(request.Description));

                return new ProjectViewModel(_repository.Create(project));
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
                var model = _repository.Find(id, "Tasks") ?? throw new ApplicationLayerException(ApplicationExceptionType.ProjectNotFound);                

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
                var model = _repository.Find(id) ?? throw new ApplicationLayerException(ApplicationExceptionType.ProjectNotFound);

                model.Finish();

                _repository.Update(model);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<ProjectViewModel> All()
        {
            try
            {
                var projects = _repository.All();

                return ProjectViewModel.ProjectsList(projects.ToList());
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<ProjectViewModel> ListMemberProjects(Guid memberId)
        {
            try
            {
                var projects = _repository.All(x => x.ManagerId == memberId);

                return ProjectViewModel.ProjectsList(projects.ToList());
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void AddTask(CreateTaskRequest request, Guid projectId)
        {
            try
            {
                var project = _repository.Find(projectId) ?? throw new ApplicationLayerException(ApplicationExceptionType.ProjectNotFound);

                project.AddTask(
                    new Name(request.Name),
                    new Description(request.Description));

                _repository.Update(project);
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
                var project = _repository.Find(projectId, "Tasks") ?? throw new ApplicationLayerException(ApplicationExceptionType.ProjectNotFound);

                project.RemoveTask(taskId);

                _repository.Update(project);
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
                var project = _repository.Find(projectId, "Tasks") ?? throw new ApplicationLayerException(ApplicationExceptionType.ProjectNotFound);
                return TaskViewModel.TasksList(project.Tasks);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
