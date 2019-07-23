using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MedicalRecords.API.Models
{
    public class Box
    {
        public int BoxId { get; set; }
        public Department Department { get; set; }
        [Required]
        public long BarcodeNum { get; set; } 
        public County County {get; set;}
        public ICollection<File> Files { get; set; }
        public bool Destroyed { get; set; }
        public string Description { get; set; }
        public string From { get; set; }   
        public string To { get; set; }
        public DateTime ActualDestructionDate { get; set; }
    }
}