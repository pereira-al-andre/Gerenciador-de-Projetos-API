using Proj.Manager.Core.Enums;
using Proj.Manager.Core.Exceptions;
using Proj.Manager.Core.Exceptions.Common;
using Proj.Manager.Core.Primitives;

namespace Proj.Manager.Core.ValueObjects
{
    public sealed class Name : ValueObject
    {
        public string Value { get; private set; }
        public Name(string value)
        {
            Validate(value);

            Value = value;
        }

        private void Validate(string value)
        {
            if (value.Length == 0) throw new DomainLayerException(DomainExceptionType.InvalidName, "Invalid name passed.");
        }
    }
}
