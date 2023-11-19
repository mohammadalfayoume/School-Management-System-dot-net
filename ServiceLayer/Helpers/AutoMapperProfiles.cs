
using AutoMapper;
using EntityLayer.DTOs.AccountDtos;
using EntityLayer.DTOs.CourseDtos;
using EntityLayer.DTOs.StudentCourseDtos;
using EntityLayer.DTOs.TeacherCourseDtos;
using EntityLayer.DTOs.UniversityDtos;
using EntityLayer.DTOs.UserDtos;
using EntityLayer.Entities;

public class AutoMaperProfiles : Profile
{
    public AutoMaperProfiles()
    {
        CreateMap<UpdateUniversityDto, University>();
        CreateMap<UpdateCourseDto, Course>();
        CreateMap<UpdateUserDto, User>();

        CreateMap<StudentCourse, StudentCourseDto>();
        CreateMap<TeacherCourse, TeacherCourseDto>();
        CreateMap<Course, CourseDto>();
        CreateMap<User, UserDto>();

        CreateMap<RegisterDto, User>();
        CreateMap<User, RegisterDto>();

        CreateMap<Course, PlanCourseDto>();
        CreateMap<User, PlanUserDto>();
        CreateMap<StudentCourse, PlanStudentCourseDto>();



    }
}
