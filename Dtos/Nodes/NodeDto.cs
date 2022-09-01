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
        public Guid HardwareId { get; set; }
        public Guid SocialMediaId { get; set; }
        public Guid ReviewId { get; set; }
        public List<Question> Questions { get; set; }
        public Guid ResourceId { get; set; }
        public Guid GuideId { get; set; }
    }
}
