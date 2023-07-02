using API.Models;

namespace API.Contracts
{
    public interface IEmployeeRepository : IGeneralRepository<Employee>
    {
        IEnumerable<Employee> GetByFirstName(string name);

        Employee? GetByEmail(string email);

        public Employee? GetByEmailAndPhoneNumber(string data);

        /*ICollection<Employee> GetAll();
        Employee? GetByGuid(Guid guid);
        Employee Create(Employee employee);
        bool Update(Employee employee);
        bool Delete(Guid guid);*/
    }
}
