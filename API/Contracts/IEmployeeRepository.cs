using API.Models;

namespace API.Contracts
{
    public interface IEmployeeRepository : IGeneralRepository<Employee>
    {
        IEnumerable<Employee> GetByFirstName(string name);
        /*ICollection<Employee> GetAll();
        Employee? GetByGuid(Guid guid);
        Employee Create(Employee employee);
        bool Update(Employee employee);
        bool Delete(Guid guid);*/
    }
}
