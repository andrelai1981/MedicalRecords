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
        
        public DateTime AnticipatedDestructionDate 
        {
            get {
                    int clientAge = DateTime.Today.Year - Client.DOB.Year;
                    DateTime clientTurns18On = Client.DOB.AddYears(18);
                    int DestructionPeriod = 7;
                    DateTime DateOfLastServicePlus7 =  Client.LastDateOfService.AddYears(DestructionPeriod);
                    DateTime result = DateOfLastServicePlus7;
 
                    if (clientAge < 18 && clientTurns18On >= DateOfLastServicePlus7)
                    {
                        result =  clientTurns18On;
                    }
                    return result;
                }
        }
        public DateTime? ActualDestructionDate { get; set; }

    }
}