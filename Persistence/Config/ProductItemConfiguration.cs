using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Config
{
    public class ProductItemConfiguration : IEntityTypeConfiguration<ProductItem>
    {
        public void Configure(EntityTypeBuilder<ProductItem> builder)
        {
            builder.ToTable("Products");

            builder.Property(x => x.Id)
                .UseHiLo("product_hilo")
                .IsRequired();

            builder.Property(x => x.Price)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(ci => ci.PictureUri)
                .IsRequired(false);

            builder.HasOne(x => x.ProductBrand)
                .WithMany()
                .HasForeignKey(x => x.ProductBrandId);

            builder.HasOne(x => x.ProductType)
                .WithMany()
                .HasForeignKey(x => x.ProductTypeId);
        }
    }
}
