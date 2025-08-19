using System.ComponentModel.DataAnnotations;

namespace StaffManagement.DTOs
{
    public class StaffDto
    {
        [Required]
        [StringLength(8, MinimumLength = 3)]
        public string? StaffId { get; set; }

        [Required]
        [StringLength(100)]
        public string? FullName { get; set; }

        [Required]
        public DateOnly Birthday { get; set; }

        [Required]
        [Range(1, 2)]
        public int Gender { get; set; }
    }
}
