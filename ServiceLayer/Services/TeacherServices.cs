using AutoMapper;
using DataLayer;
using EntityLayer.DTOs.UserDtos;
using EntityLayer.Entities;
using EntityLayer.Enums;
using Microsoft.EntityFrameworkCore;

namespace ServiceLayer.Services;

public class TeacherServices
{
    private readonly DatabaseContext _context;
    private readonly IMapper _mapper;

    public TeacherServices(DatabaseContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<User>> GetAllTeachersAsync()
    {
        var teachers = await _context.Users
            .Where(x => x.UserType == UserTypeEnum.Teacher).ToListAsync();
        return teachers;
    }
    public async Task<User> GetTeacherByIdAsync(int id)
    {
        return await _context.Users
            .FirstOrDefaultAsync(x => x.Id == id && x.UserType == UserTypeEnum.Teacher);
    }
    public async Task UpdateTeacherAsync(UpdateUserDto updatedTeacherDto)
    {
        var teacher = _mapper.Map<User>(updatedTeacherDto);
        _context.Update(teacher);
        await _context.SaveChangesAsync();
    }
}
