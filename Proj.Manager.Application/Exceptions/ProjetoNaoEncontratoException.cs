using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj.Manager.Application.Exceptions
{
    public class ProjetoNaoEncontratoException : Exception
    {
        public ProjetoNaoEncontratoException(string message) : base(message)
        { }
    }
}
