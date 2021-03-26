using ImportantEventEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportantEventDataAccess.Config
{
    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.Property(x => x.Category).IsRequired().HasMaxLength(25);
            builder.Property(x => x.Time).IsRequired().HasMaxLength(10);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(500);
        }
    }
}
