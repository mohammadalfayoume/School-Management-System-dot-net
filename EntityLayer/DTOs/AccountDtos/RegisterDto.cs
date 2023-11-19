using EntityLayer.Enums;

namespace EntityLayer.DTOs.AccountDtos;

public class RegisterDto
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public UserTypeEnum UserType { get; set; }
    public string UniversityId { get; set; }
}

