using API.DTOs.Employee;
using API.DTOs.Rooms;
using API.Models;

namespace Client.Contracts
{
    public interface IRoomRepository : IRepository<Room, Guid>
    {
    }
}
