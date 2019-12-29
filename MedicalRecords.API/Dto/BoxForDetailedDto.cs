using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MedicalRecords.API.Models;

namespace MedicalRecords.API.Dto
{
  public class BoxForDetailedDto
  {
    public int BoxId { get; set; }
    public int Department { get; set; }
    public long BarcodeNum { get; set; }
    public int County { get; set; }
    public string From { get; set; }
    public string To { get; set; }
    public string Description { get; set; }
    public ICollection<FileForBoxListDto> Files { get; set; }
    public bool Destroyed { get; set; }
  }
}