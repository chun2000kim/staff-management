namespace StaffManagement.DTOs
{
    public class SearchCriteria
    {
        public string? StaffId { get; set; }
        public int? Gender { get; set; }
        public DateOnly? DateFrom { get; set; }
        public DateOnly? DateTo { get; set; }
    }
}
