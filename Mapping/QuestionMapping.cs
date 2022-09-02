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
    public class QuestionMapping : AuditableEntityMapping<Question>
    {
        public override void Configure(EntityTypeBuilder<Question> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Title).IsRequired();
            builder.Property(x => x.Answer).IsRequired();

            builder.HasOne(x => x.Node).WithMany(x => x.Questions).HasForeignKey(x => x.NodeId);
        }
    }
}
