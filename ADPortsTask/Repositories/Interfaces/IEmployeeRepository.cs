using System.Threading.Tasks;
using ADPortsTask.Data.Models;

namespace ADPortsTask.Repositories.Interfaces
{
    public interface IEmployeeRepository
        : IActEntityRepository<Employee, int, ApplicationUser, string>
    {
    }
}