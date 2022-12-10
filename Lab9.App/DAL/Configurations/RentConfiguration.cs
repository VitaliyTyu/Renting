using Lab9.App.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lab9.App.DAL.Configurations
{
    public class RentConfiguration : IEntityTypeConfiguration<Rent>
    {
        public void Configure(EntityTypeBuilder<Rent> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Id).IsUnique();
            builder.Property(x => x.StartDate);
            builder.Property(x => x.ExpectedEndDate);
            builder.Property(x => x.ActualEndDate);
            builder
                .HasOne(x => x.Customer)
                .WithMany(x => x.Rents)
                .HasForeignKey(x => x.CustomerId);
            builder
                .HasOne(x => x.Item)
                .WithMany(x => x.Rents)
                .HasForeignKey(x => x.ItemId);
        }
    }
}