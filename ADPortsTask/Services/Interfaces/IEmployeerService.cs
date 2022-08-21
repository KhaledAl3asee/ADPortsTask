using ADPortsTask.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ADPortsTask.Services.Interfaces
{  
    public interface IEmployeeService
    {
        Task Create(string userId, Employee Employee);
        
        Task<IEnumerable<Employee>> GetEmployees();
        Task<Employee> GetDetail(int employeeId);
        Task Update(int currentEmployeeId, string userId, Employee Employee);
        Task Delete(int employeeId);
    }
}
