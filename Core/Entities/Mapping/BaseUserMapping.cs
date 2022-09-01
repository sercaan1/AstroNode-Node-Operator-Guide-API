using Core.Entities.Abstracts;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Mapping
{
    public abstract class BaseUserMapping<T> : AuditableEntityMapping<T> where T : BaseUser
    {
        public override void Configure(EntityTypeBuilder<T> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.FirstName).HasMaxLength(256).IsRequired();
            builder.Property(x => x.LastName).HasMaxLength(256).IsRequired();
            builder.Property(x => x.Email).HasMaxLength(256).IsRequired();
            builder.Property(x => x.Image).IsRequired(false);
        }
    }
}
