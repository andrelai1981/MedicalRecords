using System.ComponentModel.DataAnnotations;

namespace MedicalRecords.API.Controllers
{
  public class UserForLoginDto
  {
    public string UserName {get; set;}
    public string Password {get; set;}
    public bool IsAdmin { get; set; }
  }
}