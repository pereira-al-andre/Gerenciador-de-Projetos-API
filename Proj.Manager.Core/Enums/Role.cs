using System.ComponentModel;

namespace Proj.Manager.Core.Enums
{
    public enum Role : int
    {
        [Description("Manager")]
        Manager = 1,

        [Description("Developer")]
        Developer = 2
    }
}
