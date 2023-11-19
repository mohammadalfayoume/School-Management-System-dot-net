using EntityLayer.Entities;
using EntityLayer.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataLayer.Config;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(u => u.Name).HasMaxLength(50).IsRequired();
        builder.Property(u => u.Password).HasMaxLength(20).IsRequired();
        builder.Property(u => u.Email).HasMaxLength(50).IsRequired();
        builder.Property(u => u.UserType).IsRequired();
        //builder.Property(u => u.UserType)
        //        .HasConversion(
        //            u => u.ToString(),
        //            u => (UserTypeEnum)Enum.Parse(typeof(UserTypeEnum), u));


        builder.HasMany(u => u.StudentCourses).WithOne(c => c.Student);
        builder.HasMany(u => u.TeacherCourses).WithOne(c => c.Teacher);
        builder.HasOne(u => u.University).WithMany(un => un.Users).HasForeignKey(u => u.UniversityId);
    }
}
