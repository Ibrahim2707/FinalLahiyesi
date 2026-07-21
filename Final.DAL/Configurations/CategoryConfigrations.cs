using Final.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.DAL.Configurations
{
    public class CategoryConfigrations : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Id);
            builder.Property(x => x.Title).IsRequired()
                .HasMaxLength(1024);
            builder.Property(x => x.SubTitle).IsRequired()
                 .HasMaxLength(200);
            builder.Property(x => x.Image).IsRequired();
            builder.Property(x => x.Link).IsRequired();

        }
    }
}
