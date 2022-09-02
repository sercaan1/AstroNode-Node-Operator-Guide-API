using Core.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Guide : AuditableEntity
    {
        public string Description { get; set; }
        public Guid NodeId { get; set; }
        public virtual Node Node { get; set; }
    }
}
