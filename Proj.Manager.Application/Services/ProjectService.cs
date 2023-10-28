using Proj.Manager.Application.DTO.RequestModels.Project;
using Proj.Manager.Application.DTO.RequestModels.Task;
using Proj.Manager.Application.DTO.ViewModels;
using Proj.Manager.Application.Exceptions;
using Proj.Manager.Application.Services.Interfaces;
using Proj.Manager.Core.Entities;
using Proj.Manager.Core.Repositories;
using Proj.Manager.Core.ValueObjects;
using System.Reflection;

namespace Proj.Manager.Application.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _repository;
        private readonly ITaskRepository _taskRepository;
        private readonly IMemberRepositoy _memberRepository;
        public ProjectService(
            IProjectRepository projectRepository,
            ITaskRepository taskRepository,
            IMemberRepositoy memberRepository)
        {
            _repository = projectRepository;
            _taskRepository = taskRepository;
            _memberRepository = memberRepository;
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
                var project = _repository.Find(id) ?? throw new ProjectNotFoundException("Project not found.");

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
                var model = _repository.Find(id) ?? throw new ProjectNotFoundException("Project not found");

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
                var manager = _memberRepository.Find(request.ManagerId) ?? throw new Exception("Member not found.");

                var project = new Project(
                    manager,
                    new Name(request.Name),
                    new Description(request.Description),
                    request.StartDate,
                    request.EndDate);

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
                var model = _repository.Find(id, "Tasks") ?? throw new ProjectNotFoundException("Project not found");                

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
                    throw new ProjectNotFoundException("Project not found");

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
                var project = _repository.Find(projectId) ?? throw new Exception("Project not found.");

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
                var project = _repository.Find(projectId, "Tasks");

                if (project == null) throw new ProjectNotFoundException("Project not found");

                project.RemoveTask(taskId);

                _repository.Update(project);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
