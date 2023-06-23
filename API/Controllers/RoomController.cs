using API.Contracts;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/Room")]

public class RoomController : ControllerBase
{
    private readonly IRoomRepository _repository;
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
        if(room  is null)
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

}
