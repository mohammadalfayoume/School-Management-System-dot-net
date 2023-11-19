using AutoMapper;
using DataLayer;
using EntityLayer.DTOs.UniversityDtos;
using EntityLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace ServiceLayer.Services;

public class UniversityServices
{
    private readonly DatabaseContext _context;
    private readonly IMapper _mapper;

    public UniversityServices(DatabaseContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IList<University>> GetAllUniversitiesAsync()
    {
      var universities = await _context.Universities.ToListAsync();
      return universities;
    }
    public async Task<University> GetUniversityByIdAsync(int id)
    {
        return await _context.Universities.FirstOrDefaultAsync(x => x.Id == id);
    }
    public async Task UpdateUniversityAsync(UpdateUniversityDto updatedUniversityDto)
    {
        var university = _mapper.Map<University>(updatedUniversityDto);
        _context.Update(university);
        await _context.SaveChangesAsync();
    }
}
