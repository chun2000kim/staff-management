namespace StaffManagement.Models
{
    public class ApiResponse
    {
        public int Code { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }
        public int TotalRecord { get; set; }

        public List<Staff> Data { get; set; }

        public ApiResponse()
        {
            Data = new List<Staff>();
        }
    }
}
