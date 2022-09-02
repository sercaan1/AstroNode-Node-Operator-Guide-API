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
    public class ReviewMapping : AuditableEntityMapping<Review>
    {
        public override void Configure(EntityTypeBuilder<Review> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Prize).IsRequired(false);
            builder.Property(x => x.Difficulty).IsRequired(false);
            builder.Property(x => x.Comment).IsRequired(false);
            builder.Property(x => x.Rate).IsRequired(false);
            builder.Property(x => x.Lock).IsRequired(false);

            builder.HasOne(x => x.Node).WithOne(x => x.Review).HasForeignKey<Review>(x => x.NodeId);
        }
    }
}
