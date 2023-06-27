using API.Models;

namespace API.Contracts
{
    public interface IRoleRepository : IGeneralRepository<Role>
    {
        IEnumerable<Role> GetByName(string name);
        /*ICollection<Role> GetAll();
        Role? GetByGuid(Guid guid);
        Role Create(Role role);
        bool Update(Role role);
        bool Delete(Guid guid);*/
    }
}
