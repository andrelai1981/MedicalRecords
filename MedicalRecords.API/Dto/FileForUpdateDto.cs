using System;

namespace MedicalRecords.API.Controllers
{
  public class FileForUpdateDto
  {
        public int ClientId { get; set;}
        public string Description { get; set; }
        public bool Destroyed { get; set; }
        public DateTime AnticipatedDestructionDate { get; set; }
        public DateTime ActualDestructionDate { get; set; }
  }
}