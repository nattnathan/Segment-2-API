using API.Contracts;
using API.Data;
using API.Models;
using System.Xml.Linq;

namespace API.Repositories;

public class RoomRepository : GeneralRepository<Room>, IRoomRepository
{
    public RoomRepository(BookingDbContext context) : base(context) { }
    public IEnumerable<Room> GetByName(string name)
    {
        return _context.Set<Room>().Where(room => room.Name.Contains(name));
    }
}



















/*
public class RoomRepository : IRoomRepository
{
    private readonly BookingDbContext _context;
    public RoomRepository(BookingDbContext context)
    {
        _context = context;
    }

    public ICollection<Room> GetAll()
    {
        return _context.Set<Room>().ToList();
    }

    public Room GetByGuid(Guid guid)
    {
        return _context.Set<Room>().Find(guid);
    }

    public Room Create(Room room)
    {
        _context.Set<Room>().Add(room);
        _context.SaveChanges();

        return room;
    }

    public bool Update(Room room)
    {
        try
        {
            _context.Set<Room>().Update(room);
            _context.SaveChanges();

            return true;
        }
        catch 
        {
            return false;
        }
    }

    public bool Delete(Guid guid)
    {
        try
        {
            var room = GetByGuid(guid);
            if (room is null)
            {
                return false;
            }

            _context.Set<Room>().Remove(room);
            _context.SaveChanges();
            return true;
        }
        catch 
        {
            return false;
        }
    }
}*/
