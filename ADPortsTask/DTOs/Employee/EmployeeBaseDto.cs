using System.ComponentModel.DataAnnotations;

namespace ADPortsTask.DTOs.Employee
{
    public class EmployeeBaseDto : EmployeeMinimalDto
    {
        [Range(1, int.MaxValue, ErrorMessage = "Invalid EmployeeId identifier.")]
        public int Id { get; set; }
    }
}
