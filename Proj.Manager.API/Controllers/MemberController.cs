using Microsoft.AspNetCore.Mvc;
using Proj.Manager.Application.DTO.RequestModels.Member;
using Proj.Manager.Application.DTO.ViewModels;
using Proj.Manager.Application.Services.Interfaces;
using Proj.Manager.Core.Entities;
using Proj.Manager.Core.ValueObjects;

namespace Proj.Manager.API.Controllers
{
    [Route("api/member")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IMemberService _service;
        private readonly ITaskService _taskService;
        private readonly IProjectService _projectService;
        public MemberController(
            IMemberService memberService,
            ITaskService taskService,
            IProjectService projectService)
        {
            _service = memberService;
            _taskService = taskService;
            _projectService = projectService;

        }

        [HttpGet]
        [Route("all")]
        public IActionResult All()
        {
            try
            {
                return Ok(MemberViewModel.MembersList(_service.All().ToList()));
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
            
        }

        [HttpGet]
        [Route("{id}/find")]
        public IActionResult Find(Guid id)
        {
            try
            {
                return Ok(new MemberViewModel(_service.Find(id)));
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}/tasks")]
        public IActionResult ListMemberTasks(Guid id)
        {
            try
            {
                return Ok(TaskViewModel.TasksList(_taskService.MembersList(id).ToList()));
            }
            catch (Exception ex)
            {
                return Problem($"We encountered an issue while attempting to retrieve the tasks: {ex.Message}");
            }
           
        }

        [HttpGet]
        [Route("{id}/projects")]
        public IActionResult ListMemberProjects(Guid id)
        {
            try
            {
                return Ok(ProjectViewModel.ProjectsList(_projectService.ListMemberProjects(id).ToList()));
            }
            catch (Exception ex)
            {
                return Problem($"We encountered an issue while attempting to retrieve the projects: {ex.Message}");
            }
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Create(CreateMemberRequest request)
        {
            var member = new Member(
                new Name(request.Name), 
                new Email(request.Email), 
                new Password(request.Password), 
                request.Role);

            try
            {
                return Ok(new MemberViewModel(_service.Create(member)));
            }
            catch (Exception ex)
            {
                return Problem($"We encountered an issue while attempting create a new member: {ex.Message}");
            }
        }

        [HttpPut]
        [Route("update")]
        public IActionResult Update(UpdateMemberRequest request)
        {
            try
            {
                var member = _service.Find(request.Id);

                member.Update(new Name(request.Name), new Email(request.Email));

                _service.Update(member);

                return NoContent();
            }
            catch (Exception ex)
            {
                return Problem($"We encountered an issue while attempting to update: {ex.Message}");
            }
        }

        [HttpPut]
        [Route("update/role")]
        public IActionResult UpdateRole(UpdateRoleRequest request)
        {
            try
            {
                var member = _service.Find(request.Id);

                member.ChangeRole(request.Role);

                _service.UpdateRole(member);

                return NoContent();
            }
            catch (Exception ex)
            {
                return Problem($"We encountered an issue while attempting to update role: {ex.Message}");
            }
        }

        [HttpPut]
        [Route("update/password")]
        public IActionResult UpdatePassowrd(UpdatePasswordRequest request)
        {
            try
            {
                var member = _service.Find(request.Id);

                member.ChangePassword(new Password(request.NewPassword));

                _service.UpdatePassword(member);

                return NoContent();
            }
            catch (Exception ex)
            {
                return Problem($"We encountered an issue while attempting to update the password: {ex.Message}");
            }
        }
    }
}
