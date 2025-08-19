using System.ComponentModel.DataAnnotations;

namespace StaffManagement.Models
{
    public class Staff
    {
        [Required]
        [Key]
        [StringLength(8)]
        public string? StaffId { get; set; }

        [Required, StringLength(100)]
        public string? FullName { get; set; }

        [Required]
        public DateOnly Birthday { get; set; }
        
        [Required]
        [Range(1, 2)]
        public int Gender { get; set; }
    }
}
