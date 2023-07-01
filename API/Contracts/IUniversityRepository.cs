using API.Models;

namespace API.Contracts
{
    public interface IUniversityRepository : IGeneralRepository<University>
    {
        IEnumerable<University> GetByName(string name);
        University? GetByCodeName(string code, string name);
        /*ICollection<University> GetAll();
        University? GetByGuid(Guid guid);
        University Create(University university);
        bool Update(University university);
        bool Delete(Guid guid);*/
    }
}
