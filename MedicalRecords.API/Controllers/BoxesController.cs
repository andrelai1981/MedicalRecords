using System.Linq;
using System.Threading.Tasks;
using MedicalRecords.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MedicalRecords.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class BoxesController : ControllerBase
  {
    private readonly DataContext _context;
    public BoxesController(DataContext context)
    {
      _context = context;
    
    }
    // GET api/boxes
    [HttpGet]
    public async Task<IActionResult> GetBox() 
    {
        var boxes = await _context.Box.ToListAsync();

        return Ok(boxes);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBoxes(int id)
    {
      var box = await _context.Box.FirstOrDefaultAsync(x => x.BoxId == id);
      
      return Ok(box);
    }
  }
}