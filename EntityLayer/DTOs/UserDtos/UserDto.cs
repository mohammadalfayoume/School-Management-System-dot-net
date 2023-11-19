using EntityLayer.DTOs.StudentCourseDtos;
using EntityLayer.DTOs.TeacherCourseDtos;
using EntityLayer.DTOs.UniversityDtos;
using EntityLayer.Entities;
using EntityLayer.Enums;

namespace EntityLayer.DTOs.UserDtos;

public class UserDto : BaseDto
{
    public string Name { get; set; }
    public string Email { get; set; }
    public PlanUniversityDto University { get; set; }
    public UserTypeEnum UserType { get; set; }
    public ICollection<PlanStudentCourseDto> StudentCourses { get; set; }
    public ICollection<PlanTeacherCourseDto> TeacherCourses { get; set; }
}
