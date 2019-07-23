namespace MedicalRecords.API.Dto
{
    public class UserForListDto
    {
        public int UserId { get; set; }
        public string UserName {get; set;}
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsAdmin { get; set; }
    }
}