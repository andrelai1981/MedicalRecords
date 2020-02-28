using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

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
        private int fileCount;
        public int FileCount
        {
            get { return Files
                    .Where(f => f.Destroyed == false)
                    .Count();
                }
        }
        
        public string Description { get; set; }
        public string From { get; set; }   
        public string To { get; set; }
        public DateTime? ActualDestructionDate { get; set; }
    }
}