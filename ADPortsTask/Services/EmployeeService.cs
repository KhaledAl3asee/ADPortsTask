using ADPortsTask.Data.Models;
using ADPortsTask.Repositories.Interfaces;
using ADPortsTask.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace ADPortsTask.Services
{
    public class EmployeeService : IEmployeeService
    {
        IEmployeeRepository repository;

        public EmployeeService(IEmployeeRepository Repo)
        {
            repository = Repo;
        }

        

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await repository.GetListAsync();
        }

        public async Task<Employee> GetDetail(int id)
        {
            return await repository.GetAsync(id);
        }

        public async Task Create(string userId, Employee Employee)
        {
            Employee.UpdatedUserId = Employee.CreatedUserId = userId;
            await repository.CreateAsync(Employee);
        }

        public async Task Update(int currentEmployeeId, string userId, Employee Emp)
        {
            Emp.Id = currentEmployeeId;
            Emp.UpdatedUserId = userId;
            Emp.UpdatedTime = DateTime.Now;
            await repository.UpdateAsync(Emp);
        }

        public async Task Delete(int id) {
            await repository.DeleteAsync(id);
        } 

    }
}
