using AutoMapper;
using DataLayer;
using EntityLayer.DTOs.AccountDtos;
using EntityLayer.DTOs.UserDtos;
using EntityLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace ServiceLayer.Services;

public class AccountServices
{
    private readonly DatabaseContext _context;
    private readonly IMapper _mapper;

    public AccountServices(DatabaseContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<User> CreateAccountAsync(RegisterDto registerDto)
    {
        if (!IsValidEmail(registerDto.Email)) throw new Exception("Invalid Email");
        var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == registerDto.Email);
        if (user is not null) throw new Exception("User already exists");
        if (registerDto.Password is null || registerDto.Password.Length < 6) throw new Exception("Invalid Password");
        var userToCreate = _mapper.Map<User>(registerDto);

        await _context.Users.AddAsync(userToCreate);
        await _context.SaveChangesAsync();
        return userToCreate;
    }
    public async Task<User> LoginAsync(LoginDto loginDto)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == loginDto.Email);
        if (user is null) throw new Exception("User does not exist");
        if (user.Password != loginDto.Password) throw new Exception("Incorrect Password");
        var userToReturn = _mapper.Map<User>(user);
        return userToReturn;
    }
    private static bool IsValidEmail(string email)
    {
        string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
        Regex regex = new Regex(emailPattern);
        return regex.IsMatch(email);
    }
}
