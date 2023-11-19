using DataLayer;
using EntityLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace ServiceLayer.Services;

public class BaseServices<T> where T : BaseEntity
{
    private readonly DatabaseContext _context;

    public BaseServices(DatabaseContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }
    public async Task<T> GetById(int id)
    {
        return await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
    }
}
