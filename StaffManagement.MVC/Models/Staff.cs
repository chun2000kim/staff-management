using System.ComponentModel.DataAnnotations;

namespace StaffManagement.MVC.Models
{
    public class Staff
    {
        [Required, StringLength(8)]
        [Display(Name = "Staff ID")]
        public string StaffId { get; set; } = string.Empty;

        [Required, StringLength(100)]
        [Display(Name = "Full name")]
        public string FullName { get; set; } = string.Empty;

        [Required, DataType(DataType.Date)]
        public DateOnly Birthday { get; set; }

        [Required, Range(1, 2)]
        public int Gender { get; set; }
    }
}
