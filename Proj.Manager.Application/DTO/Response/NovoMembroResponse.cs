using Proj.Manager.Core.Entities;
using Proj.Manager.Core.Enums;
using Proj.Manager.Core.Extensions;

namespace Proj.Manager.Application.DTO.Response
{
    public class NovoMembroResponse
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string NomeCargo { get; set; } = null!;
        public ECargo CodCargo { get; set; }

        public NovoMembroResponse(Membro membro)
        {
            Id = membro.Id;
            Nome = membro.Nome;
            Email = membro.Email;
            NomeCargo = membro.Cargo.RetornarDescricao();
            CodCargo = membro.Cargo;
        }
    }
}
