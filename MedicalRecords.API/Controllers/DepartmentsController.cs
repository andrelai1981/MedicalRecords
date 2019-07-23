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
    [HttpGet]
    public async Task<IActionResult> GetDepartments()
    {
      var departments = await _repo.GetDepartments();

      return Ok(departments);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetDepartment(int id)
    {
      var department = await _repo.GetDepartment(id);

      return Ok(department);
    }
  }
}