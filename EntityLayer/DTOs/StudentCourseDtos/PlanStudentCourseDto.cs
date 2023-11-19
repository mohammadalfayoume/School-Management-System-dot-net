using EntityLayer.DTOs.CourseDtos;
using EntityLayer.DTOs.UserDtos;

namespace EntityLayer.DTOs.StudentCourseDtos;

public class PlanStudentCourseDto : BaseDto
{
    public int CourseId { get; set; }
    public int StudentId { get; set; }
}
