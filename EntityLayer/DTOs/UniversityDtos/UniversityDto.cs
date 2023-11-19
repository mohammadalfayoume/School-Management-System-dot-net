using EntityLayer.DTOs.UserDtos;
using EntityLayer.Entities;

namespace EntityLayer.DTOs.UniversityDtos;

public class UniversityDto
{
    public string Name { get; set; }
    public string Location { get; set; }
    public ICollection<PlanUserDto> Users { get; set; }
}
