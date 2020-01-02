using System.Collections.Generic;
using MedicalRecords.API.Models;

namespace MedicalRecords.API.Dto
{
    public class BoxForListDto
    {
        public int BoxId { get; set; }
        public string Department { get; set; }
        public long BarcodeNum { get; set; } 
        public string County {get; set;}
        public string From { get; set; }
        public string To { get; set; }
        public string Description { get; set; }
        public int FileCount { get; set; }
        public bool Destroyed { get; set; }
    }
}