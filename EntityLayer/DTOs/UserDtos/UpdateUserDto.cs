using EntityLayer.Enums;

namespace EntityLayer.DTOs.UserDtos;

public class UpdateUserDto
{
    public string Name { get; set; }
    public string Email { get; set; }
    public UserTypeEnum UserType { get; set; }
}
