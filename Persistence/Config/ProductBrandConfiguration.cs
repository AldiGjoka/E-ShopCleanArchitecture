using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Config
{
    public class ProductBrandConfiguration : IEntityTypeConfiguration<ProductBrand>
    {
        public void Configure(EntityTypeBuilder<ProductBrand> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .UseHiLo("product_brand_hilo")
                .IsRequired();

            builder.Property(b => b.Brand)
                .IsRequired(true)
                .HasMaxLength(100);
        }
    }
}
