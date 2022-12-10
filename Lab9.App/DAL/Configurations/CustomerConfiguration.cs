using Lab9.App.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lab9.App.DAL.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Id).IsUnique();
            builder.Property(x => x.Name);
            builder.Property(x => x.Age);
            builder.Property(x => x.Height);
            builder.Property(x => x.Weight);
            builder.Property(x => x.ShoeSizeRu);
            builder.Property(x => x.ÑlothingSizeRu);
        }
    }
}