using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj.Manager.Core.Exceptions
{
    public class InvalidPasswordException : Exception
    {
        public InvalidPasswordException(string msg) : base(msg)
        {
            
        }
    }
}
