using Lab9.App.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lab9.App.DAL.Configurations
{
    public class ItemConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Id).IsUnique();
            builder.Property(x => x.Name);
            builder.Property(x => x.QuantityOnStock);
            builder.Property(x => x.QuantityOnLease);
            builder.Property(x => x.Type);
            builder.Property(x => x.RentPrice);
            builder.Property(x => x.CostIfBroken);
            builder.Property(x => x.SizeRu);
            builder.Property(x => x.Length);
            builder.Property(x => x.Width);
            builder
                .HasOne(x => x.Country)
                .WithMany(x => x.Items)
                .HasForeignKey(x => x.CountryId);
        }
    }
}