using EntityLayer.DTOs.CourseDtos;
using EntityLayer.DTOs.UserDtos;
using EntityLayer.Entities;
using EntityLayer.Enums;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Services;

namespace MvcWebLayer.Controllers
{
    public class UserController : Controller
    {
        private readonly CourseServices _courseServices;
        private readonly StudentServices _studentServices;

        public UserController(CourseServices courseServices, StudentServices studentServices)
        {
            _courseServices = courseServices;
            _studentServices = studentServices;
        }
        public ActionResult Index(UserDto user)
        {
            return View(user);
        }
        public async Task<IActionResult> StudentCourses(int studentId)
        {
            
            var studentCourses = await _courseServices.GetStudentCoursesAsync(studentId);
            var courses = await _courseServices.GetAllCoursesAsync();
            
            return View(new { studentCourses, courses, studentId });
        }
        public async Task<IActionResult> TeacherCourses(int teacherId)
        {
            var teacherCourses = await _courseServices.GetTeacherCoursesAsync(teacherId);
            return View(new { teacherCourses, teacherId });
        }
        public async Task<IActionResult> TeacherCourseStudents(int teacherId, int courseId)
        {
            var students = await _courseServices.GetTeacherCourseStudentsAsync(teacherId, courseId);
            return View(students);
        }
    }
}
