using Core.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Resource : AuditableEntity
    {
        public string ResourceLink { get; set; }
        public Guid NodeId { get; set; }
        public virtual Node Node { get; set; }
    }
}
