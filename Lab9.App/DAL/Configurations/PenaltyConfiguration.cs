using Lab9.App.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lab9.App.DAL.Configurations
{
    public class PenaltyConfiguration : IEntityTypeConfiguration<Penalty>
    {
        public void Configure(EntityTypeBuilder<Penalty> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Id).IsUnique();
            builder.Property(x => x.Type);
            builder.Property(x => x.Price);
            builder
                .HasOne(x => x.Rent)
                .WithMany(x => x.Penalties)
                .HasForeignKey(x => x.RentId);
        }
    }
}