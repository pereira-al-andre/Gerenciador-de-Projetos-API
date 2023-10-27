using Microsoft.AspNetCore.Mvc;
using Proj.Manager.Application.DTO.RequestModels.Task;
using Proj.Manager.Application.DTO.ViewModels;
using Proj.Manager.Application.Services.Interfaces;
using Proj.Manager.Core.Entities;
using Proj.Manager.Core.ValueObjects;

namespace Proj.Manager.API.Controllers
{
    [Route("api/task")]
    [ApiController]
    public class TaskController : ControllerBase
    {

        private readonly ITaskService _service;
        private readonly IMemberService _memberService;
        public TaskController(ITaskService taskService, IMemberService memberService)
        {
            _service = taskService;
            _memberService = memberService;
        }

        [HttpGet]
        [Route("all")]
        public IActionResult All()
        {
            try
            {
                return Ok(TaskViewModel.TasksList(_service.All().ToList()));
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
                return Ok(new TaskViewModel(_service.Find(id)));
            }
            catch (Exception ex)
            {
                return Problem($"We encountered an issue while attempting to find: {ex.Message}");
            }
           
        }

        [HttpGet]
        [Route("{id}/members")]
        public IActionResult ListTaskMembers(Guid id)
        {
            try
            {
                return Ok(MemberViewModel.MembersList(_service.Find(id).Members));
            }
            catch (Exception ex)
            {
                return Problem($"We encountered an issue while attempting to get the memebers: {ex.Message}");
            }

        }

        [HttpPost]
        [Route("create")]
        public IActionResult Create(CreateTaskRequest request)
        {
            var task = new Core.Entities.Task(
                request.ProjectId, 
                new Name(request.Name), 
                new Description(request.Description), 
                request.StartDate,
                request.EndDate);

            try
            {
                return Ok(new TaskViewModel(_service.Create(task)));
            }
            catch (Exception ex)
            {
                return Problem($"We encountered an issue while attempting to create a new task: {ex.Message}");
            }
        }

        [HttpPut]
        [Route("update")]
        public IActionResult Update(UpdateTaskRequest request)
        {
            try
            {
                var task = _service.Find(request.Id);
                task.Update(new Name(request.Name), new Description(request.Description), task.EndDate);

                _service.UpdateTask(task);

                return NoContent();
            }
            catch (Exception ex)
            {
                return Problem($"We encountered an issue while attempting to update: {ex.Message}");
            }

        }

        [HttpDelete]
        [Route("{id}/delete")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var task = _service.Find(id);
                task.Delete();
                _service.UpdateTask(task);

                return NoContent();
            }
            catch (Exception ex)
            {
                return Problem($"We encountered an issue while attempting to delete: {ex.Message}");
            }
         
        }

        [HttpPut]
        [Route("{id}/cancel")]
        public IActionResult Cancel(Guid id)
        {
            try
            {
                var task = _service.Find(id);
                task.Cancel();
                _service.UpdateTask(task);

                return NoContent();
            }
            catch (Exception ex)
            {
                return Problem($"We encountered an issue while attempting to cancel: {ex.Message}");
            }

        }

        [HttpPut]
        [Route("{id}/complete")]
        public IActionResult Complete(Guid id)
        {
            try
            {
                var task = _service.Find(id);
                task.Complete();
                _service.UpdateTask(task);

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
                var task = _service.Find(id);
                task.Start();
                _service.UpdateTask(task);

                return NoContent();
            }
            catch (Exception ex)
            {
                return Problem($"We encountered an issue while attempting to start: {ex.Message}");
            }
         
        }

        [HttpPost]
        [Route("{taskId}/add/member")]
        public IActionResult AddMember(Guid memberId, Guid taskId)
        {
            try
            {
                var task = _service.Find(taskId);
                var member = _memberService.Find(memberId);
                task.AddMember(member);
                _service.UpdateTask(task);

                return NoContent();
            }
            catch (Exception ex)
            {
                return Problem($"We encountered an issue while attempting to add a member: {ex.Message}");
            }
            
        }
    }
}
