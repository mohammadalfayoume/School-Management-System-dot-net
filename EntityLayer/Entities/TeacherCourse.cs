namespace EntityLayer.Entities;

public class TeacherCourse : BaseEntity
{
    public Course Course { get; set; }
    public User Teacher { get; set; }
    public int CourseId { get; set; }
    public int TeacherId { get; set; }
}
