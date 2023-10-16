using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Proj.Manager.Application.DTO.RequestModels.Projeto
{
    public class AtualizarProjetoRequest {

        [Required]
        public Guid Id { get; set; }

        [AllowNull]
        [MaxLength(50)]
        public string Nome { get; set; } = null;

        [AllowNull]
        [MaxLength(255)]
        public string Descricao { get; set; } = null;

        [AllowNull]
        public DateTime DataPrazo { get; set; }

    }
}
