using Proj.Manager.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace Proj.Manager.Application.DTO.RequestModels.Member
{
    public class UpdateRoleRequest
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public Role Role { get; set; }
    }
}
