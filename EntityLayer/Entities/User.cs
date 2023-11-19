using EntityLayer.Enums;

namespace EntityLayer.Entities;

public class User : BaseEntity
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public University University { get; set; }
    public int UniversityId { get; set; }
    public UserTypeEnum UserType { get; set; }
    public ICollection<StudentCourse> StudentCourses { get; set; }
    public ICollection<TeacherCourse> TeacherCourses { get; set; }
}
