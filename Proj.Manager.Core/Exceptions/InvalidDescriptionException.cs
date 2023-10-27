using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj.Manager.Core.Exceptions
{
    public class InvalidDescriptionException : Exception
    {
        public InvalidDescriptionException(string msg) : base(msg)
        {
            
        }
    }
}
