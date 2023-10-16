using System.ComponentModel.DataAnnotations;

namespace Proj.Manager.Application.DTO.RequestModels.Membro
{
    public class AlterarSenhaRequest
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        [MinLength(6)]
        public string SenhaAtual { get; set; } = null!;

        [Required]
        [MinLength(6)]
        public string NovaSenha { get; set; } = null!;
    }
}
