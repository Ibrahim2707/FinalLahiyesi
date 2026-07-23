using Final.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Final.DAL.Configurations
{
    public class BasketItemConfigurations : IEntityTypeConfiguration<BasketItem>
    {
        public void Configure(EntityTypeBuilder<BasketItem> builder)
        {
            builder.Property(x => x.BasketKey).IsRequired().HasMaxLength(64);
            builder.Property(x => x.Quantity).IsRequired();
            builder.HasIndex(x => new { x.BasketKey, x.ProductId }).IsUnique();
            builder.HasOne(x => x.Product)
                .WithMany(x => x.BasketItems)
                .HasForeignKey(x => x.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
