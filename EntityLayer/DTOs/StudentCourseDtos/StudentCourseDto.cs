using EntityLayer.DTOs.CourseDtos;
using EntityLayer.DTOs.UserDtos;

namespace EntityLayer.DTOs.StudentCourseDtos;

public class StudentCourseDto : PlanStudentCourseDto
{

    public PlanCourseDto Course { get; set; }
    public PlanUserDto Student { get; set; }
    
}
