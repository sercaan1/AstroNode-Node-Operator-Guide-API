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
    public class SocialMediaMapping : AuditableEntityMapping<SocialMedia>
    {
        public override void Configure(EntityTypeBuilder<SocialMedia> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.TwitterLink).IsRequired(false);
            builder.Property(x => x.TelegramLink).IsRequired(false);
            builder.Property(x => x.WebPageLink).IsRequired(false);
            builder.Property(x => x.DiscordLink).IsRequired(false);

            builder.HasOne(x => x.Node).WithOne(x => x.SocialMedia).HasForeignKey<SocialMedia>(x => x.NodeId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
