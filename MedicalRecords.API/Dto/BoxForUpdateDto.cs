using System;

namespace MedicalRecords.API.Controllers
{
  public class BoxForUpdateDto
  {
    public int Department { get; set; }
    public int County { get; set; }
    public string From { get; set; }
    public string To { get; set; }
    public string Description { get; set; }
    public bool Destroyed { get; set; }
    public DateTime? ActualDestructionDate {get; set;}
  }
}