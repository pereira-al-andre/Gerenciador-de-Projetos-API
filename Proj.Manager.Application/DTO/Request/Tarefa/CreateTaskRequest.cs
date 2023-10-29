using System.ComponentModel.DataAnnotations;

namespace Proj.Manager.Application.DTO.RequestModels.Task
{
    public sealed class CreateTaskRequest
    {
        public CreateTaskRequest(
            string name, 
            string description)
        {
            Name = name;
            Description = description;
        }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(255)]
        public string Description { get; set; } = null!;
    }
}
