using Proj.Manager.Core.Enums;
using Proj.Manager.Core.Exceptions.Interfaces;
using Proj.Manager.Core.Extensions;

namespace Proj.Manager.Core.Exceptions.Common
{
    public class DomainLayerException : Exception, IDomainException
    {
        public DomainExceptionType Type { get; private set; }
        public DomainLayerException(DomainExceptionType type, string message) : base($"{type.GetDescription()}: {message}")
        {
            Type = type;
        }

        public DomainLayerException(DomainExceptionType type) : base(type.GetDescription())
        {
            Type = type;
        }
    }
}
