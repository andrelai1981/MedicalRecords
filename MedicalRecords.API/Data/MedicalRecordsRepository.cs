using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicalRecords.API.Helpers;
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
        .ThenInclude(c => c.Client)
        .FirstOrDefaultAsync(b => b.BoxId == id);

      return box;
    }

    public async Task<PagedList<Box>> GetBoxes(BoxParams boxParams)
    {
      var boxes = _context.Boxes
        .Include(d => d.Department)
        .Include(c => c.County)
        .Include(f => f.Files)
        .OrderBy(b => b.BarcodeNum)
        .AsQueryable();

      if (boxParams.BarcodeNum != 0) {
        boxes = boxes.Where(f => f.BarcodeNum == boxParams.BarcodeNum); 
      }
      if (boxParams.DepartmentId != 0) {
        boxes = boxes.Where(f => f.Department.DepartmentId == boxParams.DepartmentId); 
      }
      if (boxParams.CountyId != 0) {
        boxes = boxes.Where(f => f.County.CountyId == boxParams.CountyId); 
      }
      if (boxParams.ShowDestroyed != 2) {
        if (boxParams.ShowDestroyed == 0) {
          boxes = boxes.Where(f => f.Destroyed == false); 
        }
        else if (boxParams.ShowDestroyed == 1) {
          boxes = boxes.Where(f => f.Destroyed == true); 
        }
      }

      return await PagedList<Box>.CreateAsync(boxes, boxParams.PageNumber, boxParams.PageSize);
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

    public async Task<IEnumerable<Client>> GetClients()
    {
      var clients = await _context.Clients.ToListAsync();

      return clients;
    }
    public async Task<User> GetUser(int id)
    {
      var user = await _context.Users.FirstOrDefaultAsync(u => u.UserId == id);

      return user;
    }

    public async Task<PagedList<File>> GetFiles(FileParams fileParams)
    {
      var files = _context.Files
        .Include(b => b.Box)
        .Include(c => c.Client)
        .OrderBy(b => b.Box.BarcodeNum)
        .ThenBy(f => f.FileId)
        .AsQueryable();
      
      if (fileParams.BarcodeNum != 0) {
        files = files.Where(f => f.Box.BarcodeNum == fileParams.BarcodeNum); 
      }
      if (fileParams.ClientId != 0) {
        files = files.Where(f => f.Client.ClientId == fileParams.ClientId); 
      }
      if (fileParams.ShowDestroyed != 2) {
        if (fileParams.ShowDestroyed == 0) {
          files = files.Where(f => f.Destroyed == false); 
        }
        else if (fileParams.ShowDestroyed == 1) {
          files = files.Where(f => f.Destroyed == true); 
        }
      }

      return await PagedList<File>.CreateAsync(files, fileParams.PageNumber, fileParams.PageSize);
    }
    // public async Task<IEnumerable<File>> GetFilesForBox(int id)
    // {
    //   var files = await _context.Files
    //     .Where(f => f.Box.BoxId == id)
    //     .Include(c => c.Client)
    //     .ToListAsync();

    //   return files;
    // }

    public async Task<File> GetFile(int id)
    {
      var file = await _context.Files
        .Include(b => b.Box)
        .Include(c => c.Client)
        .FirstOrDefaultAsync(u => u.FileId == id);

      return file;
    }

    public async Task<bool> BoxExists(long barcodeNum)
    {
      if (await _context.Boxes.AnyAsync(x => x.BarcodeNum == barcodeNum))
        return true;

      return false;
    }

    public async Task<Box> CreateBox(Box box)
    {
      await _context.Boxes.AddAsync(box);
      await _context.SaveChangesAsync();

      return box;
    }

    public async Task<Department> GetDepartment(int id) 
    {
      var department = await _context.Departments.FirstOrDefaultAsync(d => d.DepartmentId == id);

      return department;
    }
    public async Task<County> GetCounty(int id) 
    {
      var county = await _context.Counties.FirstOrDefaultAsync(d => d.CountyId == id);

      return county;
    }

    public async Task<File> CreateFile(File file)
    {
      await _context.Files.AddAsync(file);
      await _context.SaveChangesAsync();

      return file;
    }

    public async Task<Client> GetClient(int id)
    {
      var client = await _context.Clients.FirstOrDefaultAsync(c => c.ClientId == id);

      return client;
    }

    public async Task<int> GetNumberOfFilesInBox(int id)
    {
      var numberOfFiles = await _context.Files
        .Where(file => file.Box.BoxId == id && file.Destroyed == false)
        .CountAsync();

      return numberOfFiles;
    }
  }
}