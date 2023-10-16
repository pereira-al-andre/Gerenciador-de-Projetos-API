using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Proj.Manager.Application.DTO.RequestModels.Projeto
{
    public class CriarProjetoRequest
    {
        [Required]
        public Guid GerenteId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Nome { get; set; } = null!;

        [AllowNull]
        [MaxLength(255)]
        public string Descricao { get; set; } = null;

        [Required]
        public DateTime DataInicio { get; set; }

        [AllowNull]
        public DateTime DataPrazo { get; set; }
    }
}
