using AutoMapper;
using EntityLayer.DTOs.CourseDtos;
using EntityLayer.DTOs.TeacherCourseDtos;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Services;

namespace MvcWebLayer.Controllers;

public class CourseController : Controller
{
    private readonly CourseServices _courseService;
    private readonly IMapper _mapper;
    public CourseController(CourseServices courseService, IMapper mapper)
    {
        _courseService = courseService;
        _mapper = mapper;
    }
    public async Task<IActionResult> Index()
    {
        var courses = await _courseService.GetAllCoursesAsync();
        return View(courses);
    }
    public async Task<IActionResult> Details(int id)
    {
        var course = await _courseService.GetCourseByIdAsync(id);
        return View(course);
    }

    [HttpPost]
    public async Task<IActionResult> AddCourseToStudent(int studentId, int courseId)
    {
        await _courseService.AddCourseToUserAsync(studentId, courseId);
        return RedirectToAction("StudentCourses","User", new { studentId });
    }
    [HttpPost]
    public async Task<IActionResult> AddCourseToTeacher(int teacherId, int courseId)
    {
        await _courseService.AddCourseToUserAsync(teacherId, courseId);
        return RedirectToAction("TeacherCourses", "User");
    }
    [HttpGet]
    public async Task<IActionResult> RemoveStudentCourse(int studentId, int courseId)
    {
        await _courseService.RemoveStudentCourseAsync(studentId, courseId);
        return RedirectToAction("StudentCourses", "User", new { studentId });
    }
    //[HttpDelete]
    //public async Task<IActionResult> DeleteCourse(int courseId)
    //{
    //    await _courseService.Del
    //    return RedirectToAction("StudentCourses", "User", new { studentId });
    //}
    public IActionResult NewCourseForm(int teacherId)
    {
        return View(teacherId);
    }
    [HttpPost]
    public async Task<IActionResult> AddCourse(CreateTeacherCourseDto courseDto)
    {
        var courseToCreate = new Course
        {
            CourseName = courseDto.CourseName
        };
        var course =await _courseService.CreateCourseAsync(courseToCreate);
        await _courseService.AddCourseToUserAsync(courseDto.TeacherId, course.Id);
        return RedirectToAction("TeacherCourses", "User",new { courseDto.TeacherId});
        //var newCourse = 
        //await _courseService.
        //return RedirectToAction("StudentCourses", "User", new { studentId });
    }
}
