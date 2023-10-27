using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Proj.Manager.Application.DTO.RequestModels.Task
{
    public class UpdateTaskRequest
    {
        [Required]
        public Guid Id { get; set; }

        [AllowNull]
        [MaxLength(50)]
        public string Name { get; set; } = null;

        [AllowNull]
        [MaxLength(255)]
        public string Description { get; set; } = null;

        [AllowNull]
        public DateTime EndDate { get; set; }
    }
}
