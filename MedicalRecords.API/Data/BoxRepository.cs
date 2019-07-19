using System.Threading.Tasks;
using MedicalRecords.API.Models;
using Microsoft.EntityFrameworkCore;

namespace MedicalRecords.API.Data
{
  public class BoxRepository : IBoxRepository
  {
    private readonly DataContext _context;
    public BoxRepository(DataContext context)
    {
        _context = context; 
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
  }
}