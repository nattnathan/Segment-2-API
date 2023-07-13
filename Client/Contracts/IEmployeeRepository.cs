using API.DTOs.Employee;
using API.Models;

namespace Client.Contracts
{
    public interface IEmployeeRepository : IRepository<GetEmployeeDto, Guid>
    {
    }
}
