using Dtos.Hardwares;
using Dtos.SocialMedias;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.Nodes
{
    public class NodeListDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public HardwareDto Hardware { get; set; }
        public SocialMediaDto SocialMedia { get; set; }
    }
}
