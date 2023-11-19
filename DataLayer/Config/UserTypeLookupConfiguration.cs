using EntityLayer.LookupEntitis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataLayer.Config;

public class UserTypeLookupConfiguration : IEntityTypeConfiguration<UserTypeLookup>
{
    public void Configure(EntityTypeBuilder<UserTypeLookup> builder)
    {
        builder.Property(ut => ut.UserType).HasMaxLength(20).IsRequired();
    }
}
