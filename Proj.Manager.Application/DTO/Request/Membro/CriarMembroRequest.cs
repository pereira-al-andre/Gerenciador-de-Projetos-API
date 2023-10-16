using Proj.Manager.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace Proj.Manager.Application.DTO.RequestModels.Membro
{
    public class CriarMembroRequest
    {
        [Required]
        public string Nome { get; set; } = null!;

        [Required]
        public string Email { get; set; } = null!;

        [Required]
        [MinLength(6)]
        public string Senha { get; set; } = null!;

        [Required]
        public ECargo Cargo { get; set; }
    }
}
