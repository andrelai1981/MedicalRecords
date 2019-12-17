using System;

namespace MedicalRecords.API.Dto
{
    public class FileForCreateDto
    {
        public int FileId { get; set; }
        public int Box {get; set;}
        public int Client { get; set; }
        public bool Destroyed { get; set; }
        public string Description {get; set; }
        public DateTime AnticipatedDestructionDate { get; set; }
        public DateTime ActualDestructionDate { get; set; }

    }
}