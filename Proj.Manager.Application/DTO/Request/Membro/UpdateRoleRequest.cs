using Proj.Manager.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace Proj.Manager.Application.DTO.RequestModels.Member
{
    public class UpdateRoleRequest
    {
        public UpdateRoleRequest(Guid id, Role role)
        {
            Id = id;
            Role = role;
        }

        [Required]
        public Guid Id { get; set; }

        [Required]
        public Role Role { get; set; }
    }
}
