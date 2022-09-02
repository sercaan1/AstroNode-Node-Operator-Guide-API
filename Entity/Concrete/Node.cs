using Core.Entities.Abstracts;
using Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Node : AuditableEntity
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public virtual Hardware Hardware { get; set; }
        public virtual SocialMedia SocialMedia { get; set; }
        public virtual Review Review { get; set; }
        public virtual List<Question> Questions { get; set; }
        public virtual Resource Resource { get; set; }
        public virtual Guide Guide { get; set; }
    }
}
