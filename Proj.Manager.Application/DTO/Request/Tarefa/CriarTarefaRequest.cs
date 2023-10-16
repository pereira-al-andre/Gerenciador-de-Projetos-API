using System.ComponentModel.DataAnnotations;

namespace Proj.Manager.Application.DTO.RequestModels.Tarefa
{
    public class CriarTarefaRequest
    {
        [Required]
        public Guid ProjetoId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Nome { get; set; } = null!;

        [Required]
        [MaxLength(255)]
        public string Descricao { get; set; } = null!;

        [Required]
        public DateTime DataInicio { get; set; } = DateTime.Now;
        public DateTime? DataPrazo { get; set; } = null;
    }
}
