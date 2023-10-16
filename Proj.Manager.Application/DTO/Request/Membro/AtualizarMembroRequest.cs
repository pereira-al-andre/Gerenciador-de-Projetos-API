using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Proj.Manager.Application.DTO.RequestModels.Membro
{
    public class AtualizarMembroRequest
    {
        [Required]
        public Guid Id { get; set; }

        [AllowNull]
        [MaxLength(50)]
        public string Nome { get; set; } = null;

        [AllowNull]
        [MaxLength(255)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null;
    }
}
