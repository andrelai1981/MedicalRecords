namespace MedicalRecords.API.Models
{
    public class File
    {
        public int FileId { get; set; }
        public Box Box { get; set; }
        public Client Client {get; set;}
        public string Description { get; set; }
        public string From { get; set; }   
        public string To { get; set; }
        public bool Destroyed { get; set; }

    }
}