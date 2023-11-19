using EntityLayer.DTOs.StudentCourseDtos;
using EntityLayer.DTOs.TeacherCourseDtos;
using EntityLayer.Entities;
using EntityLayer.Enums;

namespace EntityLayer.DTOs.UserDtos;

public class PlanUserDto : BaseDto
{
    public string Name { get; set; }
    public string Email { get; set; }
    public UserTypeEnum UserType { get; set; }
}
