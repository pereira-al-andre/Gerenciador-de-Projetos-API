using System.ComponentModel;

namespace Proj.Manager.Core.Enums
{
    public enum EStatusProjeto : int
    {
        [Description("Não Iniciado")]
        NaoIniciado = 0,

        [Description("Em Andamento")]
        EmAndamento = 1,

        [Description("Finalizada")]
        Finalizada = 2,

        [Description("Cancelada")]
        Cancelada = 3,

        [Description("Deletada")]
        Deletada = 4
    }
}
