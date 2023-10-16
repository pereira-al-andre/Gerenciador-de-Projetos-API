using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Proj.Manager.Core.Enums
{
    public enum ECargo : int
    {
        [Description("Gerente")]
        Gerente = 1,

        [Description("Desenvolvedor")]
        Desenvolvedor = 2
    }
}
