using EntityLayer.DTOs.CourseDtos;
using EntityLayer.DTOs.UserDtos;

namespace EntityLayer.DTOs.TeacherCourseDtos;

public class PlanTeacherCourseDto : BaseDto
{
    public int CourseId { get; set; }
    public int TeacherId { get; set; }
}
