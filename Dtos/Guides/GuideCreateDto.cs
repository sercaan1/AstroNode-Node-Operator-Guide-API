using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.Guides
{
    public class GuideCreateDto
    {
        public Guid NodeId { get; set; }
        public string Description { get; set; }
    }
}
