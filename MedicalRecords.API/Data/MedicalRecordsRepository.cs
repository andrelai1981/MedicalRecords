using System.Collections.Generic;
using System.Threading.Tasks;
using MedicalRecords.API.Models;
using Microsoft.EntityFrameworkCore;

namespace MedicalRecords.API.Data
{
  public class MedicalRecordsRepository : IMedicalRecordsRepository
  {
    private readonly DataContext _context;
    public MedicalRecordsRepository(DataContext context)
    {
      _context = context;
    }
    public void Add<T>(T entity) where T : class
    {
      _context.Add(entity);
    }

    public void Delete<T>(T entity) where T : class
    {
      _context.Remove(entity);
    }

    public async Task<Box> GetBox(int id)
    {
      var box = await _context.Boxes
        .Include(d => d.Department)
        .Include(c => c.County)
        .Include(f => f.Files)
        .FirstOrDefaultAsync(b => b.BoxId == id);

      return box;
    }

    public async Task<IEnumerable<Box>> GetBoxes()
    {
      var boxes = await _context.Boxes
        .Include(d => d.Department)
        .Include(c => c.County)
        .Include(f => f.Files)
        .ToListAsync();

      return boxes;
    }

    public async Task<IEnumerable<Department>> GetDepartments()
    {
      var departments = await _context.Departments.ToListAsync();

      return departments;
    }
    public async Task<IEnumerable<County>> GetCounties()
    {
      var counties = await _context.Counties.ToListAsync();

      return counties;
    }
    public async Task<bool> SaveAll()
    {
      return await _context.SaveChangesAsync() > 0;
    }

    public async Task<IEnumerable<User>> GetUsers()
    {
      var users = await _context.Users.ToListAsync();

      return users;
    }
    public async Task<User> GetUser(int id)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.UserId == id);

        return user;
    }
  }
}