using Core.Entities.Abstracts;
using Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Node : AuditableEntity
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Guid HardwareId { get; set; }
        public Hardware Hardware { get; set; }
        public Guid SocialMediaId { get; set; }
        public SocialMedia SocialMedia { get; set; }
        public Guid ReviewId { get; set; }
        public Review Review { get; set; }
        public List<Question> Questions { get; set; }
        public Guid ResourceId { get; set; }
        public Resource Resource { get; set; }
        public Guid GuideId { get; set; }
        public Guide Guide { get; set; }
    }
}
