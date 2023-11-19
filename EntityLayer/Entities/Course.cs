namespace EntityLayer.Entities;

public class Course : BaseEntity
{
    public string CourseName { get; set; }
    public ICollection<StudentCourse> StudentCourses { get; set; }
    public ICollection<TeacherCourse> TeacherCourses { get; set; }
}
