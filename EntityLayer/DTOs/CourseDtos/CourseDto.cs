using EntityLayer.DTOs.StudentCourseDtos;
using EntityLayer.DTOs.TeacherCourseDtos;
using EntityLayer.Entities;

namespace EntityLayer.DTOs.CourseDtos;

public class CourseDto : BaseDto
{
    public string CourseName { get; set; }
    public ICollection<PlanStudentCourseDto> StudentCourses { get; set; }
    public ICollection<PlanTeacherCourseDto> TeacherCourses { get; set; }
}
