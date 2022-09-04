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
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? ReviewRate { get; set; }
        public int? ReviewDifficulty { get; set; }
    }
}
