using Core.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Abstracts
{
    public abstract class AuditableEntity : BaseEntity, IDeletableEntity
    {
        public string DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
