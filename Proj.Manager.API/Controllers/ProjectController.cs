using Microsoft.AspNetCore.Mvc;
using Proj.Manager.Application.DTO.RequestModels.Project;
using Proj.Manager.Application.DTO.RequestModels.Task;
using Proj.Manager.Application.Services.Interfaces;

namespace Proj.Manager.API.Controllers
{
    [Route("api/project")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _service;
        public ProjectController(
            IProjectService projectService)
        {
            _service = projectService;
        }

        [HttpGet]
        [Route("all")]
        public IActionResult All()
        {
            try
            {
                return Ok(_service.All());
            }
            catch (Exception ex)
            {
                return Problem($"We encountered an issue while attempting to get all: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("{projectId}/find")]
        public IActionResult Find(Guid projectId)
        {
            try
            {
                return Ok(_service.Find(projectId));
            }
            catch (Exception ex)
            {
                return Problem($"We encountered an issue while attempting to find the project: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("{projectId}/tasks")]
        public IActionResult ListTasks(Guid projectId)
        {
            try
            {
                return Ok(_service.ListProjectTasks(projectId));
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
            try
            {
                return Ok(_service.Create(request));
            }
            catch (Exception ex)
            {
                return Problem($"We encountered an issue while attempting to create e new project: {ex.Message}");
            }
        }

        [HttpDelete]
        [Route("{projectId}/delete")]
        public IActionResult Delete(Guid projectId)
        {
            try
            {
                _service.Delete(projectId);

                return NoContent();
            }
            catch (Exception ex)
            {
                return Problem($"We encountered an issue while attempting to delete: {ex.Message}");
            }
        }

        [HttpPut]
        [Route("{projectId}/cancel")]
        public IActionResult Cancel(Guid projectId)
        {
            try
            {
                _service.Cancel(projectId);
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
                _service.Update(request);

                return NoContent();
            }
            catch (Exception ex)
            {
                return Problem($"We encountered an issue while attempting to update: {ex.Message}");
            }
        }

        [HttpPost]
        [Route("{projectId}/add/task")]
        public IActionResult AddTask(CreateTaskRequest request, Guid projectId)
        {
            try
            {
                _service.AddTask(request, projectId);

                return NoContent();
            }
            catch (Exception ex)
            {
                return Problem($"We encountered an issue while attempting to remove the task: {ex.Message}");
            }
        }

        [HttpDelete]
        [Route("{projectId}/remove/task/{taskId}")]
        public IActionResult RemoveTask(Guid taskId, Guid projectId)
        {
            try
            {
                _service.RemoveTask(taskId, projectId);

                return NoContent();
            }
            catch (Exception ex)
            {
                return Problem($"We encountered an issue while attempting to remove the task: {ex.Message}");
            }
        }
    }
}
