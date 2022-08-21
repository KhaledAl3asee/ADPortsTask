using ADPortsTask.Data;
using ADPortsTask.Data.Models;
using ADPortsTask.DTOs.Employee;
using ADPortsTask.Repositories.Bases;
using ADPortsTask.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ADPortsTask.Repositories
{
    public class EmployeeRepository
        : ActEntityRepositoryBase<Employee, int, ApplicationUser, string>, 
        IEmployeeRepository
    {
        public EmployeeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task UpdateAsync(Employee Employee)
        {
            await UpdateSelectiveAsync<EmployeeUpdateSubsetDto>(Employee);
        }

 

    }

}
