using System.Collections.Generic;

namespace MedicalRecords.API.Models
{
  public class County
  {
      public int CountyId { get; set; }
      public string CountyName { get; set; }
      public ICollection<Box> Box { get; set; }
  }
}