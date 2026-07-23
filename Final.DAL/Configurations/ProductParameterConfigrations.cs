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
    public class ProductParameterConfigrations : IEntityTypeConfiguration<ProductParameter>
    {
        public void Configure(EntityTypeBuilder<ProductParameter> builder)
        {
            builder.Property(x => x.Name)
                 .HasMaxLength(100)
                 .IsRequired();

            builder.Property(x => x.Value)
                   .HasMaxLength(200)
                   .IsRequired();


            builder.HasOne(x => x.Product)
                   .WithMany(x => x.ProductParameters)
                   .HasForeignKey(x => x.ProductId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
        
    }
}
