using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj.Manager.Application.Exceptions
{
    public class MembroNaoEncontratoException : Exception
    {
        public MembroNaoEncontratoException(string message) : base(message)
        { }
    }
}
