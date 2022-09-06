using Dtos.Hardwares;
using Dtos.Reviews;
using Dtos.SocialMedias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.Nodes
{
    public class NodeUpdateDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public HardwareUpdateDto Hardware { get; set; }
        public ReviewUpdateDto Review { get; set; }
        public SocialMediaUpdateDto SocialMedia { get; set; }
    }
}
