using System.Collections.Generic;

namespace MedicalRecords.API.Models
{
    public class Box
    {
        public int BoxId { get; set; }
        public Department Department { get; set; }
        public long BarcodeNum { get; set; } 
        public County County {get; set;}
        public ICollection<File> Files { get; set; }
        public bool Destroyed { get; set; }
    }
}