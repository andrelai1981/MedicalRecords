using MedicalRecords.API.Models;

namespace MedicalRecords.API.Dto
{
    public class BoxForCreateDto
    {
        public long BarcodeNum { get; set; }
        public Department Department {get; set;}
        public County County { get; set; }
    }
}