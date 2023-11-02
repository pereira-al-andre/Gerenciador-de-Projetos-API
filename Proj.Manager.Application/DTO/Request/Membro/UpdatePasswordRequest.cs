using System.ComponentModel.DataAnnotations;

namespace Proj.Manager.Application.DTO.RequestModels.Member
{
    public class UpdatePasswordRequest
    {
        public UpdatePasswordRequest(Guid id, string currentPassword, string newPassword)
        {
            Id = id;
            CurrentPassword = currentPassword;
            NewPassword = newPassword;
        }

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
