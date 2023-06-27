using API.DTOs.Rooms;
using API.Services;
using API.Utilities;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers;

[ApiController]
[Route("api/Rooms")]

public class RoomController : ControllerBase
{
    private readonly RoomService _service;

    public RoomController(RoomService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var rooms = _service.GetRoom();
        if (rooms == null)
        {
            return NotFound(new ResponseHandler<GetRoomDto>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Data Not Found"

            });
        }

        return Ok(new ResponseHandler<IEnumerable<GetRoomDto>>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "All Data Found",
            Data = rooms
        });
    }

    [HttpGet("{guid}")]
    public IActionResult GetByGuid(Guid guid)
    {
        var room = _service.GetRoom(guid);
        if (room is null)
        {
            return NotFound(new ResponseHandler<GetRoomDto>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Data not found"
            });
        }

        return Ok(new ResponseHandler<GetRoomDto>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Data found",
            Data = room
        });
    }

    [HttpPost]
    public IActionResult Create(NewRoomDto newRoomDto)
    {
        var createdRoom = _service.CreateRoom(newRoomDto);
        if (createdRoom is null)
        {
            return BadRequest(new ResponseHandler<GetRoomDto>
            {
                Code = StatusCodes.Status400BadRequest,
                Status = HttpStatusCode.BadRequest.ToString(),
                Message = "Data not created"
            });
        }

        return Ok(new ResponseHandler<GetRoomDto>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Successfully created",
            Data = createdRoom
        });
    }

    [HttpPut]
    public IActionResult Update(GetRoomDto updateRoomDto)
    {
        var update = _service.UpdateRoom(updateRoomDto);
        if (update is -1)
        {
            return NotFound(new ResponseHandler<GetRoomDto>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Id not found"
            });
        }
        if (update is 0)
        {
            return BadRequest(new ResponseHandler<GetRoomDto>
            {
                Code = StatusCodes.Status500InternalServerError,
                Status = HttpStatusCode.InternalServerError.ToString(),
                Message = "Check your data"
            });
        }
        return Ok(new ResponseHandler<GetRoomDto>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Successfully updated"
        });
    }

    [HttpDelete]
    public IActionResult Delete(Guid guid)
    {
        var delete = _service.DeleteRoom(guid);

        if (delete is -1)
        {
            return NotFound(new ResponseHandler<GetRoomDto>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Id not found"
            });
        }
        if (delete is 0)
        {
            return BadRequest(new ResponseHandler<GetRoomDto>
            {
                Code = StatusCodes.Status500InternalServerError,
                Status = HttpStatusCode.InternalServerError.ToString(),
                Message = "Check connection to database"
            });
        }

        return Ok(new ResponseHandler<GetRoomDto>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Successfully deleted"
        });
    }

    [HttpGet("name/{name}")]
    public IActionResult GetByName(string name)
    {
        var room = _service.GetRoom(name);
        if (!room.Any())
        {
            return NotFound(new ResponseHandler<GetRoomDto>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Data By Name Not Found"
            });
        }

        return Ok(new ResponseHandler<IEnumerable<GetRoomDto>>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Data By Name Found",
            Data = room
        });
    }
}
















/*private readonly IRoomRepository _repository;
public RoomController(IRoomRepository repository)
{
    _repository = repository;
}

[HttpGet]
public IActionResult GetAll()
{
    var room = _repository.GetAll();
    return Ok(room);
}

[HttpGet("{guid}")]
public IActionResult GetByGuid(Guid guid)
{
    var room = _repository.GetByGuid(guid);
    if (room is null)
    {
        return NotFound();
    }

    return Ok(room);
}

[HttpPost]
public IActionResult Create(Room room)
{
    var createRoom = _repository.Create(room);
    return Ok(createRoom);
}

[HttpPut]
public IActionResult Update(Room room)
{
    var isUpdate = _repository.Update(room);
    if (!isUpdate)
    {
        return NotFound();
    }

    return Ok();
}

[HttpDelete]
public IActionResult Delete(Guid guid)
{
    var isDelete = _repository.Delete(guid);
    if (!isDelete)
    {
        return NotFound();
    }

    return Ok();
}
*/