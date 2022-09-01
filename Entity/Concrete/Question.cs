using Core.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Question : AuditableEntity
    {
        public string Title { get; set; }
        public string Answer { get; set; }
        public Guid NodeId { get; set; }
        public Node Node { get; set; }
    }
}
