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
    public class NodeCreateDto
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public HardwareCreateDto Hardware { get; set; }
        public ReviewCreateDto Review { get; set; }
        public SocialMediaCreateDto SocialMedia { get; set; }
    }
}
