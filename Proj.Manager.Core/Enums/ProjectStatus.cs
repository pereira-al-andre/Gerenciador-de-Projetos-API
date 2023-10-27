using System.ComponentModel;

namespace Proj.Manager.Core.Enums
{
    public enum ProjectStatus : int
    {
        [Description("Todo")]
        ToDo = 0,

        [Description("On Going")]
        OnGoing = 1,

        [Description("Completed")]
        Completed = 2,

        [Description("Canceled")]
        Canceled = 3,

        [Description("Deleted")]
        Deleted = 4
    }
}
