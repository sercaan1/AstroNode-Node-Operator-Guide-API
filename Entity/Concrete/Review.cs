using Core.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Review : AuditableEntity
    {
        public string Comment { get; set; }
        public int Rate { get; set; }
        public int Difficulty { get; set; }
        public string Prize { get; set; }
        public string Lock { get; set; }
    }
}
