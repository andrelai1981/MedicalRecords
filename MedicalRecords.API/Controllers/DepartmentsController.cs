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
  public class DepartmentsController : ControllerBase
  {
    private readonly IMedicalRecordsRepository _repo;
    public DepartmentsController(IMedicalRecordsRepository repo)
    {
      _repo = repo;

    }
    // GET api/departments
    [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> GetDepartments()
    {
      var departments = await _repo.GetDepartments();

      return Ok(departments);
    }
  }
}