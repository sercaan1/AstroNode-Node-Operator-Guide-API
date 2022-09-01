using Core.Entities.Mapping;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapping
{
    public class AdminMapping : BaseUserMapping<Admin>
    {
        public override void Configure(EntityTypeBuilder<Admin> builder)
        {
            base.Configure(builder);
        }
    }
}
