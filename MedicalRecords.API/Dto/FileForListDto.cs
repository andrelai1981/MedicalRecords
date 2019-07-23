namespace MedicalRecords.API.Dto
{
    public class FileForListDto
    {
        public int FileId { get; set; }
        public int ClientId {get; set;}
        public string Description { get; set; }        
        public bool Destroyed { get; set; }
    }
}