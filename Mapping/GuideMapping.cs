using Core.Entities.Mapping;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapping
{
    public class GuideMapping : AuditableEntityMapping<Guide>
    {
        public override void Configure(EntityTypeBuilder<Guide> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Description).IsRequired();

            builder.HasOne(x => x.Node).WithOne(x => x.Guide).HasForeignKey<Guide>(x => x.NodeId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
