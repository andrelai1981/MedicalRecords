using System.Collections.Generic;
using MedicalRecords.API.Models;

namespace MedicalRecords.API.Dto
{
    public class BoxForDetailedDto
    {
        public int BoxId { get; set; }
        public Department Department { get; set; }
        public long BarcodeNum { get; set; } 
        public County County {get; set;}
        public ICollection<FileForBoxListDto> Files { get; set; }
        public bool Destroyed { get; set; }
    }
}