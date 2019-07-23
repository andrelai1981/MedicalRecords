using System.Collections.Generic;

namespace MedicalRecords.API.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public ICollection<Box> Box { get; set; }
    }
}