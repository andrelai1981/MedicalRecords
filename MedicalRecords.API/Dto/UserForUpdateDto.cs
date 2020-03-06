using System.ComponentModel.DataAnnotations;
namespace MedicalRecords.API.Controllers
{
  public class UserForUpdateDto
  {
        public int UserId {get; set;}
        public string UserName { get; set; }
        public string LastName { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        [StringLength(8, MinimumLength = 4, ErrorMessage = "You must specify password between 4 and 8")] 
        public string Password  {get; set;}
        public bool IsAdmin { get; set; }
  }
}