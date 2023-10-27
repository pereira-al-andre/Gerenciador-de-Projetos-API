using System.ComponentModel.DataAnnotations;

namespace Proj.Manager.Application.DTO.RequestModels.Member
{
    public class UpdatePasswordRequest
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        [MinLength(6)]
        public string CurrentPassword { get; set; } = null!;

        [Required]
        [MinLength(6)]
        public string NewPassword { get; set; } = null!;
    }
}
