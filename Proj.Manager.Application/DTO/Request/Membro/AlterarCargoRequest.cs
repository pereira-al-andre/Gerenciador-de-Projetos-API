using Proj.Manager.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace Proj.Manager.Application.DTO.RequestModels.Membro
{
    public class AlterarCargoRequest
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        [Range(1,3)]
        [DataType(DataType.Custom)]
        public ECargo Cargo { get; set; }
    }
}
