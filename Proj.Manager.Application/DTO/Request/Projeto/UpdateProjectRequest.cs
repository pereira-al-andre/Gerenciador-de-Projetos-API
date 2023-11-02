using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Proj.Manager.Application.DTO.RequestModels.Project
{
    public class UpdateProjectRequest {

        public UpdateProjectRequest(Guid id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        [Required]
        public Guid Id { get; set; }

        [AllowNull]
        [MaxLength(50)]
        public string Name { get; set; } = null;

        [AllowNull]
        [MaxLength(255)]
        public string Description { get; set; } = null;

    }
}
