using AutoMapper;
using DataLayer;
using EntityLayer.DTOs.UserDtos;
using EntityLayer.Entities;
using EntityLayer.Enums;
using Microsoft.EntityFrameworkCore;

namespace ServiceLayer.Services;

public class StudentServices
{
    private readonly DatabaseContext _context;
    private readonly IMapper _mapper;

    public StudentServices(DatabaseContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<User>> GetAllStudentsAsync()
    {
        var students = await _context.Users
            .Where(x => x.UserType == UserTypeEnum.Student).ToListAsync();
        return students;
    }
    public async Task<User> GetStudentByIdAsync(int id)
    {
        return await _context.Users
            .FirstOrDefaultAsync(x => x.Id == id && x.UserType==UserTypeEnum.Student);
    }
    public async Task UpdateStudentAsync(UpdateUserDto updatedStudentDto)
    {
        var student = _mapper.Map<User>(updatedStudentDto);
        _context.Update(student);
        await _context.SaveChangesAsync();
    }
    public async Task AddStudentToCourse(int studentId, int courseId)
    {
        var student = await _context.Users.FindAsync(studentId);
        var course = await _context.Courses.FindAsync(courseId);
    }
}
