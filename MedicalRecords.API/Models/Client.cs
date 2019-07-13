using System;

namespace MedicalRecords.API.Models
{
  public class Client
  {
      public int ClientId { get; set; }
      public string LastName { get; set; }
      public string FirstName { get; set; }
      public DateTime DOB { get; set; }
  }
}