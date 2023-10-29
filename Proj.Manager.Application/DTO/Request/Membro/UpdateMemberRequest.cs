using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Proj.Manager.Application.DTO.RequestModels.Member
{
    public class UpdateMemberRequest
    {
        [Required]
        public Guid Id { get; set; }

        [AllowNull]
        [MaxLength(50)]
        public string? Name { get; set; } = null;

        [AllowNull]
        [MaxLength(255)]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; } = null;
    }
}
