using System;

namespace MedicalRecords.API.Dto
{
    public class FileForDetailDto
    {
        public int FileId { get; set; }
        public int BoxId {get; set;}
        public long BarcodeNum {get; set;}
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public bool Destroyed { get; set; }
        public string Description {get; set; }
        public DateTime? AnticipatedDestructionDate { get; set; }
        public DateTime? ActualDestructionDate { get; set; }

    }
}