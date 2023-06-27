using API.Contracts;
using API.DTOs.Rooms;
using API.DTOs.Universities;
using API.Models;

namespace API.Services;

public class RoomService
{
    private readonly IRoomRepository _roomRepository;

    public RoomService(IRoomRepository roomRepository)
    {
        _roomRepository = roomRepository;
    }

    public IEnumerable<GetRoomDto>? GetRoom()
    {
        var rooms = _roomRepository.GetAll();
        if (!rooms.Any())
        {
            return null;
        }

        var toDto = rooms.Select(room => new GetRoomDto
        {
            Guid = room.Guid,
            Name = room.Name,
            Floor = room.Floor,
            Capacity = room.Capacity
        });

        return toDto;
    }

    public GetRoomDto? GetRoom(Guid guid)
    {
        var room = _roomRepository.GetByGuid(guid);
        if (room is null)
        {
            return null; // room not found
        }

        var toDto = new GetRoomDto
        {
            Guid = room.Guid,
            Name = room.Name,
            Floor = room.Floor,
            Capacity = room.Capacity
        };

        return toDto; // room found
    }

    public IEnumerable<GetRoomDto>? GetRoom(string name)
    {
        var rooms = _roomRepository.GetByName(name);
        if (!rooms.Any())
        {
            return null; // No Room found
        }

        var toDto = rooms.Select(room => new GetRoomDto                                   
        {
            Guid = room.Guid,
            Name = room.Name,
            Floor = room.Floor,
            Capacity = room.Capacity

        }).ToList();

        return toDto; // Rooms found
    }

    public GetRoomDto? CreateRoom(NewRoomDto newRoomDto)
    {
        var room = new Room
        {
            Name = newRoomDto.Name,
            Floor = newRoomDto.Floor,
            Capacity = newRoomDto.Capacity,
            Guid = new Guid(),
            CreatedDate = DateTime.Now,
            ModifiedDate = DateTime.Now
        };

        var createdRoom = _roomRepository.Create(room);
        if (createdRoom is null)
        {
            return null; // Room not created
        }

        var toDto = new GetRoomDto
        {
            Guid = createdRoom.Guid,
            Name = createdRoom.Name,
            Floor = createdRoom.Floor,
            Capacity = createdRoom.Capacity
        };

        return toDto; // Room created

    }

    public int UpdateRoom(GetRoomDto updateRoomDto)
    {
        var isExist = _roomRepository.IsExist(updateRoomDto.Guid);
        if (!isExist)
        {
            return -1; // Not Found
        }

        var getRoom = _roomRepository.GetByGuid(updateRoomDto.Guid);
        var room = new Room
        {
            Guid = updateRoomDto.Guid,
            Floor = updateRoomDto.Floor,
            Name = updateRoomDto.Name,
            Capacity = updateRoomDto.Capacity,
            ModifiedDate = DateTime.Now,
            CreatedDate = getRoom!.CreatedDate
        };

        var isUpdate = _roomRepository.Update(room);
        if (!isUpdate)
        {
            return 0; // Room not updated
        }

        return 1; // Succes Update
    }

    public int DeleteRoom(Guid guid)
    {
        var isExist = _roomRepository.IsExist(guid);
        if (!isExist)
        {
            return -1; 
        }

        var room = _roomRepository.GetByGuid(guid);
        var isDelete = _roomRepository.Delete(room!);
        if (!isDelete)
        {
            return 0; 
        }

        return 1;
    }
}
