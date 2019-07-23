using MedicalRecords.API.Models;

namespace MedicalRecords.API.Dto
{
    public class FileForBoxListDto
    {
        public int FileId { get; set; }
        public string Client {get; set;}
        public string Description { get; set; }        
        public bool Destroyed { get; set; }
    }
}