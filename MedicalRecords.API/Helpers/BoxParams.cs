namespace MedicalRecords.API.Helpers
{
    public class BoxParams
    {
        private const int MaxPageSize = 50;
        public int PageNumber { get; set; } = 1;
        private int pageSize = 10;
        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = (value > MaxPageSize) ? MaxPageSize : value; }
        }

        public int UserId { get; set; }
        public int DepartmentId { get; set; }
        public int CountyId { get; set; }
        public int ShowDestroyed { get; set; } = 0;
        public long BarcodeNum { get; set; }
        public string OrderBy { get; set; } 
        
    }
}