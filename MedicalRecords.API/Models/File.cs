using System;

namespace MedicalRecords.API.Models
{
    public class File
    {
        public int FileId { get; set; }
        public Box Box { get; set; }
        public Client Client { get; set;}
        public string Description { get; set; }
        public bool Destroyed { get; set; }
        public DateTime AnticipatedDestructionDate { get; set; }
        public DateTime ActualDestructionDate { get; set; }

    }
}