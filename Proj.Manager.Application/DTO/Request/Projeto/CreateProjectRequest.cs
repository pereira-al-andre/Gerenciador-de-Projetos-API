using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Proj.Manager.Application.DTO.RequestModels.Project
{
    public class CreateProjectRequest
    {
        public CreateProjectRequest(Guid managerId, string name, string description)
        {
            ManagerId = managerId;
            Name = name;
            Description = description;
        }


        [Required]
        public Guid ManagerId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = null!;

        [AllowNull]
        [MaxLength(255)]
        public string Description { get; set; } = null;
    }
}
