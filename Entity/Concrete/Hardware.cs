using Core.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Hardware : AuditableEntity
    {
        public string CPU { get; set; }
        public string RAM { get; set; }
        public string Storage { get; set; }
        public string DownloadSpeed { get; set; }
        public Guid NodeId { get; set; }
        public Node Node { get; set; }
    }
}
