using System.ComponentModel;

namespace Proj.Manager.Core.Enums
{
    public enum EStatusProjeto : int
    {
        [Description("Não Iniciado")]
        NaoIniciado = 0,

        [Description("Em Andamento")]
        EmAndamento = 1,

        [Description("Finalizado")]
        Finalizado = 2,

        [Description("Cancelado")]
        Cancelado = 3,

        [Description("Deletado")]
        Deletado = 4
    }
}
