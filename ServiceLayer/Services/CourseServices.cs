using AutoMapper;
using DataLayer;
using EntityLayer.DTOs.CourseDtos;
using EntityLayer.DTOs.StudentCourseDtos;
using EntityLayer.DTOs.TeacherCourseDtos;
using EntityLayer.Entities;
using EntityLayer.Enums;
using Microsoft.EntityFrameworkCore;

namespace ServiceLayer.Services;

public class CourseServices
{
    private readonly DatabaseContext _context;
    private readonly IMapper _mapper;

    public CourseServices(DatabaseContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<Course> CreateCourseAsync(Course courseToCreate)
    {
        await _context.AddAsync(courseToCreate);
        await _context.SaveChangesAsync();
        return courseToCreate;
    }

    public async Task<IList<CourseDto>> GetAllCoursesAsync()
    {
        var courses = await _context.Courses.ToListAsync();
        var coursesToReturn = _mapper.Map<IList<CourseDto>>(courses);
        return coursesToReturn;
    }
    public async Task<Course> GetCourseByIdAsync(int id)
    {
        return await _context.Courses
            .FirstOrDefaultAsync(x => x.Id == id);
    }
    public async Task UpdateCourseAsync(UpdateCourseDto updatedCourseDto)
    {
        var course = _mapper.Map<Course>(updatedCourseDto);
        _context.Update(course);
        await _context.SaveChangesAsync();
    }
    public async Task<IList<User>> GetTeacherCourseStudentsAsync(int teacherId, int courseId)
    {
        var students = await _context.Users.
            Include(x => x.StudentCourses)
            .Where(user => user.UserType == UserTypeEnum.Student && user.StudentCourses.
                Any(sc => sc.CourseId == courseId)).ToListAsync();
        
        return students;
    }
    public async Task<IList<StudentCourseDto>> GetStudentCoursesAsync(int studentId)
    {
        var stdCourses = await _context.StudentCourses.Where(x => x.StudentId== studentId).Include(x => x.Course).Include(x => x.Student).ToListAsync();
        return _mapper.Map<IList<StudentCourseDto>>(stdCourses);
    }
    public async Task<IList<TeacherCourseDto>> GetTeacherCoursesAsync(int teacherId)
    {
        var teacCourses = await _context.TeacherCourses.Where(x => x.TeacherId == teacherId).Include(x => x.Course).Include(x => x.Teacher).ToListAsync();
        return _mapper.Map<IList<TeacherCourseDto>>(teacCourses);
    }

    public async Task AddCourseToUserAsync(int userId, int courseId)
    {
        var user = await _context.Users.Include(x=>x.StudentCourses).Include(x=>x.TeacherCourses).FirstOrDefaultAsync(x => x.Id == userId);
        if (user is null) throw new Exception("User does not exist");
        var course = await _context.Courses.Include(x=>x.StudentCourses).Include(x => x.TeacherCourses).FirstOrDefaultAsync(x => x.Id == courseId);
        if (course is null) throw new Exception("Course does not exist");
        if (user.UserType == UserTypeEnum.Student)
        {
            foreach (var c in user.StudentCourses)
            {
                if (c.CourseId == courseId) throw new Exception("Student already registerd in this course");
            }
            var studentCourse = new StudentCourse()
            {
                Course = course,
                CourseId = courseId,
                Student = user,
                StudentId = userId
            };
            await _context.StudentCourses.AddAsync(studentCourse);
            
        }
        else if(user.UserType == UserTypeEnum.Teacher)
        {
            foreach (var c in user.TeacherCourses)
            {
                if (c.CourseId == courseId) throw new Exception("Teacher already has this course");
            }
            var teacherCourse = new TeacherCourse()
            {
                Course = course,
                CourseId = courseId,
                Teacher = user,
                TeacherId = userId
            };
            await _context.TeacherCourses.AddAsync(teacherCourse);
        }
        await _context.SaveChangesAsync();
    }

    public async Task RemoveStudentCourseAsync(int studentId, int courseId)
    {
        var user = await _context.Users.Include(x => x.StudentCourses).FirstOrDefaultAsync(x => x.Id == studentId);
        if (user is null) throw new Exception("User does not exist");
        var course = await _context.Courses.Include(x => x.StudentCourses).FirstOrDefaultAsync(x => x.Id == courseId);
        if (course is null) throw new Exception("Course does not exist");
        foreach(var c in course.StudentCourses)
        {
            if (c.CourseId == courseId)
            {
                c.Course = null;
            }
        }
        await _context.SaveChangesAsync();
    }
}
