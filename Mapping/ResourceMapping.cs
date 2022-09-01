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
    public class ResourceMapping : AuditableEntityMapping<Resource>
    {
        public override void Configure(EntityTypeBuilder<Resource> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.ResourceLink).IsRequired();

            builder.HasOne(x => x.Node).WithOne(x => x.Resource).HasForeignKey<Resource>(x => x.NodeId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
