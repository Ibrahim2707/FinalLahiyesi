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
    public class BlogConfigrations:IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            builder.Property(x => x.Title)
         .HasMaxLength(200)
         .IsRequired();

            builder.Property(x => x.Description)
                   .HasMaxLength(1000);

            builder.HasOne(x => x.Category)
                   .WithMany(x => x.Blogs)
                   .HasForeignKey(x => x.CategoryId)
                   .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
