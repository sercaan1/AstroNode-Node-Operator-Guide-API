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
    public class NodeMapping : AuditableEntityMapping<Node>
    {
        public override void Configure(EntityTypeBuilder<Node> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Name).HasMaxLength(256).IsRequired();
            builder.Property(x => x.Image).IsRequired(false);
            builder.Property(x => x.StartDate).IsRequired(false);
            builder.Property(x => x.EndDate).IsRequired(false);
        }
    }
}
