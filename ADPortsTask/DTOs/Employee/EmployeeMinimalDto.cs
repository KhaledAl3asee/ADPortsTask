using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ADPortsTask.DTOs.Employee
{
    public class EmployeeMinimalDto
    {
        [Required]
        [StringLength(64, MinimumLength = 3, ErrorMessage = "Title should be no more 64 characters")]
        public string Title { get; set; }

        [Column(TypeName = "bit")]
        public bool? IsActive { get; set; }
    }
}
