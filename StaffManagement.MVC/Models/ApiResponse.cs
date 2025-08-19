namespace StaffManagement.MVC.Models
{
    public class ApiResponse<T>
    {
        public int Code { get; set; }
        public string? Status { get; set; }
        public string? Message { get; set; }
        public int TotalRecord { get; set; }
        public T? Data { get; set; }
    }
}
