using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.SocialMedias
{
    public class SocialMediaDto
    {
        public Guid Id { get; set; }
        public string TwitterLink { get; set; }
        public string TelegramLink { get; set; }
        public string WebPageLink { get; set; }
        public string DiscordLink { get; set; }
        public Guid NodeId { get; set; }
    }
}
