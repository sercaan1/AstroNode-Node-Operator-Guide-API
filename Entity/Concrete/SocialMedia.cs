using Core.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class SocialMedia : AuditableEntity
    {
        public string TwitterLink { get; set; }
        public string TelegramLink { get; set; }
        public string WebPageLink { get; set; }
        public string DiscordLink { get; set; }
        public Guid NodeId { get; set; }
        public virtual Node Node { get; set; }
    }
}
