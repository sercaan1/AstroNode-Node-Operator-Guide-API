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

            builder.HasOne(x => x.Hardware).WithOne(x => x.Node).HasForeignKey<Node>(x => x.HardwareId).OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.SocialMedia).WithOne(x => x.Node).HasForeignKey<Node>(x => x.SocialMediaId).OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Review).WithOne(x => x.Node).HasForeignKey<Node>(x => x.ReviewId).OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Resource).WithOne(x => x.Node).HasForeignKey<Node>(x => x.ResourceId).OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Guide).WithOne(x => x.Node).HasForeignKey<Node>(x => x.GuideId).OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.Questions).WithOne(x => x.Node).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
