using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Final.Core.Entities;
namespace Final.DAL.Configurations
{
    public class AboutConfigrations : IEntityTypeConfiguration<AboutUs>
    {
        public void Configure(EntityTypeBuilder<AboutUs> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Id);
            builder.Property(x => x.Description).IsRequired()
                .HasMaxLength(1024);
            builder.Property(x => x.Title).IsRequired()
                 .HasMaxLength(200);
            builder.Property(x => x.Image).IsRequired();
           
        }
    }
}
