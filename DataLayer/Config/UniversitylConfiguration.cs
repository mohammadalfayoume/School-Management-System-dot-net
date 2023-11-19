using EntityLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataLayer.Config;

public class UniversitylConfiguration : IEntityTypeConfiguration<University>
{
    public void Configure(EntityTypeBuilder<University> builder)
    {
        builder.Property(u => u.Name).HasMaxLength(50).IsRequired();
        builder.Property(u => u.Location).HasMaxLength(50).IsRequired();

    }
}
