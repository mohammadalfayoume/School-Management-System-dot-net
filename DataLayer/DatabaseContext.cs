using EntityLayer.Entities;
using EntityLayer.LookupEntitis;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DataLayer;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<Course> Courses { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<University> Universities { get; set; }
    public DbSet<StudentCourse> StudentCourses { get; set; }
    public DbSet<TeacherCourse> TeacherCourses { get; set; }
    public DbSet<UserTypeLookup> UserTypes { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
