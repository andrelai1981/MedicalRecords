using MedicalRecords.API.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MedicalRecords.API.Dto
{
    public class BoxForCreateDto
    {
        public int BoxId { get; set; }
        [Required]
        [Range(1000,999999999999)]
        public long BarcodeNum { get; set; }
        public int Department {get; set;}
        public int County { get; set; }
        public string From { get; set; }   
        public string To { get; set; }
        public string Description { get; set; }
        public ICollection<File> Files { get; set; }
        public bool Destroyed { get; set; }
        public DateTime ActualDestructionDate { get; set; }
    }
}