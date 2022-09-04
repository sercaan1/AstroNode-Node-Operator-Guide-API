using Dtos.Hardwares;
using Dtos.Reviews;
using Dtos.SocialMedias;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.Nodes
{
    public class NodeDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public HardwareDto Hardware { get; set; }
        public ReviewDto Review { get; set; }
        public SocialMediaDto SocialMedia { get; set; }
    }
}
