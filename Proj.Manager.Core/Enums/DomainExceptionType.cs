using System.ComponentModel;

namespace Proj.Manager.Core.Enums
{
    public enum DomainExceptionType
    {
        [Description("Invalid e-mail value passed")]
        InvalidEmail = 1,

        [Description("Invalid name value passed")]
        InvalidName = 2,

        [Description("Invalid description value passed")]
        InvalidDescription = 3,

        [Description("Invalid password value passed")]
        InvalidPassword = 4,

        [Description("Invalid project status")]
        InvalidProjectStatus = 5,

        [Description("Invalid task status")]
        InvalidTaskStatus = 6,

        [Description("ProjectTask not found in the project")]
        TaskNotFoundInTheProject = 7,
    }
}
