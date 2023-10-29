using Microsoft.AspNetCore.Mvc;
using Proj.Manager.Application.DTO.RequestModels.Task;
using Proj.Manager.Application.Services.Interfaces;

namespace Proj.Manager.API.Controllers
{
    [Route("api/task")]
    [ApiController]
    public class TaskController : ControllerBase
    {

        private readonly ITaskService _service;
        public TaskController(ITaskService taskService)
        {
            _service = taskService;
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
        [Route("{id}/find")]
        public IActionResult Find(Guid id)
        {
            try
            {
                return Ok(_service.Find(id));
            }
            catch (Exception ex)
            {
                return Problem($"We encountered an issue while attempting to find: {ex.Message}");
            }
           
        }

        [HttpGet]
        [Route("{taskId}/members")]
        public IActionResult ListMembers(Guid taskId)
        {
            try
            {
                return Ok(_service.ListTaskMembers(taskId));
            }
            catch (Exception ex)
            {
                return Problem($"We encountered an issue while attempting to get the memebers: {ex.Message}");
            }
        }

        [HttpPut]
        [Route("update")]
        public IActionResult Update(UpdateTaskRequest request)
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

        [HttpPost]
        [Route("{taskId}/add/member")]
        public IActionResult AddMember(Guid[] members, Guid taskId)
        {
            try
            {
                _service.AddMembers(members, taskId);

                return NoContent();
            }
            catch (Exception ex)
            {
                return Problem($"We encountered an issue while attempting to add a member: {ex.Message}");
            }
            
        }

        [HttpPost]
        [Route("{taskId}/remove/member")]
        public IActionResult RemoveMember(Guid memberId, Guid taskId)
        {
            try
            {
                _service.RemoveMember(memberId, taskId);

                return NoContent();
            }
            catch (Exception ex)
            {
                return Problem($"We encountered an issue while attempting to remove a member: {ex.Message}");
            }

        }
    }
}
