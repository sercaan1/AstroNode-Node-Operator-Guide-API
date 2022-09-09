using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Exceptions
{
    public class NotFoundException : Exception
    {
        protected NotFoundException(string message) : base(message)
        {

        }
    }

    public sealed class NodeNotFoundException : NotFoundException
    {
        public NodeNotFoundException(Guid nodeId) : base($"The node with {nodeId} does not exist!")
        {
        }
    }
}
