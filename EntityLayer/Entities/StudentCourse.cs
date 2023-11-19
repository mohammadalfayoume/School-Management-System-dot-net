namespace EntityLayer.Entities;

public class StudentCourse : BaseEntity
{
    public Course Course { get; set; }
    public User Student { get; set; }
    public int CourseId { get; set; }
    public int StudentId { get; set; }
}
