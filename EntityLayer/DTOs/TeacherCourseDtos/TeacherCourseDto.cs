using EntityLayer.DTOs.CourseDtos;
using EntityLayer.DTOs.UserDtos;
using EntityLayer.Entities;

namespace EntityLayer.DTOs.TeacherCourseDtos;

public class TeacherCourseDto : BaseDto
{
    public PlanCourseDto Course { get; set; }
    public PlanUserDto Teacher { get; set; }
    public int CourseId { get; set; }
    public int TeacherId { get; set; }
}
