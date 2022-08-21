using System;

namespace ADPortsTask.DTOs.Employee
{
    /// <summary>
    /// Helper object, lists all update properties.
    /// </summary>
    public class EmployeeUpdateSubsetDto : EmployeeMinimalDto
    {
        public DateTime UpdatedTime { get; set; }
        public string UpdatedUserId { get; set; }
    }
}
