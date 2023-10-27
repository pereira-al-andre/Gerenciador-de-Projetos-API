using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj.Manager.Core.Exceptions
{
    public class InvalidNameException : Exception
    {
        public InvalidNameException(string msg) : base(msg)
        {
            
        }
    }
}
