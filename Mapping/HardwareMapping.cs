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
    public class HardwareMapping : AuditableEntityMapping<Hardware>
    {
        public override void Configure(EntityTypeBuilder<Hardware> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.RAM).HasMaxLength(64).IsRequired(false);
            builder.Property(x => x.CPU).HasMaxLength(64).IsRequired(false);
            builder.Property(x => x.DownloadSpeed).HasMaxLength(64).IsRequired(false);
            builder.Property(x => x.Storage).HasMaxLength(64).IsRequired(false);

            builder.HasOne(x => x.Node).WithOne(x => x.Hardware).HasForeignKey<Hardware>(x => x.NodeId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
