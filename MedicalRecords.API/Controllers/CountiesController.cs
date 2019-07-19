using System.Threading.Tasks;
using MedicalRecords.API.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MedicalRecords.API.Controllers
{
  [Authorize]
  [Route("api/[controller]")]
  [ApiController]
  public class CountiesController : ControllerBase
  {
    private readonly IMedicalRecordsRepository _repo;
    public CountiesController(IMedicalRecordsRepository repo)
    {
      _repo = repo;

    }
    // GET api/counties
    [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> GetCounties()
    {
      var counties = await _repo.GetCounties();

      return Ok(counties);
    }
  }
}