using Proj.Manager.Application.Enums;
using Proj.Manager.Application.Exceptions.Interfaces;
using Proj.Manager.Core.Extensions;

namespace Proj.Manager.Application.Exceptions.Common
{
    public class ApplicationLayerException : Exception, IApplicationException
    {
        public ApplicationExceptionType Type { get; private set; }
        public ApplicationLayerException(ApplicationExceptionType type, string message) : base($"{type.GetDescription()}: {message}")
        {
            Type = type;
        }

        public ApplicationLayerException(ApplicationExceptionType type) : base(type.GetDescription())
        {
            Type = type;
        }
    }
}
