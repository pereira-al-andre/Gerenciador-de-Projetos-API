using Proj.Manager.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace Proj.Manager.Application.DTO.RequestModels.Member
{
    public class CreateMemberRequest
    {
        public CreateMemberRequest(string name, string email, string password, Role role)
        {
            Name = name;
            Email = email; 
            Password = password;
            Role = role;
        }

        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public string Email { get; set; } = null!;

        [Required]
        [MinLength(6)]
        public string Password { get; set; } = null!;

        [Required]
        public Role Role { get; set; }
    }
}
