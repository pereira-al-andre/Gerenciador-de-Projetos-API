using Microsoft.AspNetCore.Mvc;
using Proj.Manager.Application.DTO.RequestModels.Member;
using Proj.Manager.Application.Services.Interfaces;

namespace Proj.Manager.API.Controllers
{
    [Route("api/member")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IMemberService _service;
        public MemberController(
            IMemberService memberService)
        {
            _service = memberService;
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
                return Problem(ex.Message);
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
                return Problem(ex.Message);
            }
        }

        [HttpGet]
        [Route("{memberId}/tasks")]
        public IActionResult ListTasks(Guid memberId)
        {
            try
            {
                return Ok(_service.ListMemberTasks(memberId));
            }
            catch (Exception ex)
            {
                return Problem($"We encountered an issue while attempting to retrieve the tasks: {ex.Message}");
            }
           
        }

        [HttpGet]
        [Route("{memberId}/projects")]
        public IActionResult ListProjects(Guid memberId)
        {
            try
            {
                return Ok(_service.ListMemberProjects(memberId));
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
            try
            {
                return Ok(_service.Create(request));
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
                _service.Update(request);

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
                _service.UpdateRole(request);

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
                _service.UpdatePassword(request);

                return NoContent();
            }
            catch (Exception ex)
            {
                return Problem($"We encountered an issue while attempting to update the password: {ex.Message}");
            }
        }
    }
}
