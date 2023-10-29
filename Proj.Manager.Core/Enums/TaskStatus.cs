using System.ComponentModel;

namespace Proj.Manager.Core.Enums
{
    public enum TaskStatus : int
    {
        [Description("Todo")]
        ToDo = 0,

        [Description("On Going")]
        OnGoing = 1,

        [Description("Completed")]
        Completed = 2,

        [Description("Deleted")]
        Deleted = 3
    }
}
