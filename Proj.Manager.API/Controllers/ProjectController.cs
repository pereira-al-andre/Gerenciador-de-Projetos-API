using Microsoft.AspNetCore.Mvc;
using Proj.Manager.Application.DTO.RequestModels.Project;
using Proj.Manager.Application.DTO.ViewModels;
using Proj.Manager.Application.Services.Interfaces;
using Proj.Manager.Core.Entities;
using Proj.Manager.Core.ValueObjects;

namespace Proj.Manager.API.Controllers
{
    [Route("api/project")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _service;
        private readonly ITaskService _taskService;
        public ProjectController(
            IProjectService projectService, 
            ITaskService taskService)
        {
            _service = projectService;
            _taskService = taskService;
        }

        [HttpGet]
        [Route("all")]
        public IActionResult All()
        {
            try
            {
                return Ok(ProjectViewModel.ProjectsList(_service.All().ToList()));
            }
            catch (Exception ex)
            {
                return Problem($"We encountered an issue while attempting to get all: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("{id}/find")]
        public IActionResult Find(Guid id)
        {
            try
            {
                return Ok(new ProjectViewModel(_service.Find(id)));
            }
            catch (Exception ex)
            {
                return Problem($"We encountered an issue while attempting to find the project: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("{id}/tasks")]
        public IActionResult ListProjectTasks(Guid id)
        {
            try
            {
                return Ok(TaskViewModel.TasksList(_taskService.ListProjectTasks(id).ToList()));
            }
            catch (Exception ex)
            {
                return Problem($"We encountered an issue while attempting to list the projects: {ex.Message}");
            }
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Create(CreateProjectRequest request)
        {
            var project = new Project(request.ManagerId, new Name(request.Name), new Description(request.Description), request.StartDate);

            try
            {
                return Ok(new ProjectViewModel(_service.Create(project)));
            }
            catch (Exception ex)
            {
                return Problem($"We encountered an issue while attempting to create e new project: {ex.Message}");
            }
        }

        [HttpDelete]
        [Route("{id}/delete")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _service.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return Problem($"We encountered an issue while attempting to delete: {ex.Message}");
            }
        }

        [HttpPut]
        [Route("{id}/complete")]
        public IActionResult Complete(Guid id)
        {
            try
            {
                _service.Complete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return Problem($"We encountered an issue while attempting to complete: {ex.Message}");
            }
        }

        [HttpPut]
        [Route("{id}/start")]
        public IActionResult Start(Guid id)
        {
            try
            {
                _service.Start(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return Problem($"We encountered an issue while attempting to start: {ex.Message}");
            }
        }

        [HttpPut]
        [Route("{id}/cancel")]
        public IActionResult Cancel(Guid id)
        {
            try
            {
                _service.Cancel(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return Problem($"We encountered an issue while attempting to cancel: {ex.Message}");
            }
        }

        [HttpPut]
        [Route("update")]
        public IActionResult Update(UpdateProjectRequest request)
        {
            try
            {
                var project = _service.Find(request.Id);
                project.Update(new Name(request.Name), new Description(request.Description), request.EndDate);

                _service.Update(project);
                return NoContent();
            }
            catch (Exception ex)
            {
                return Problem($"We encountered an issue while attempting to update: {ex.Message}");
            }
        }

        [HttpDelete]
        [Route("{id}/remove/task")]
        public IActionResult RemoveTask(Guid idTask, Guid idProject)
        {
            try
            {
                _service.RemoveTask(idTask, idProject);

                return NoContent();
            }
            catch (Exception ex)
            {
                return Problem($"We encountered an issue while attempting to remove the task: {ex.Message}");
            }
        }
    }
}
