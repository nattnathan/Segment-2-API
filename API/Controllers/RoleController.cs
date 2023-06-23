using API.Contracts;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/Roles")]

public class RoleController : GeneralController<Role>
{
    public RoleController(IRoleRepository repository) : base(repository) { }
}
















/*private readonly IRoleRepository _repository;
    public RoleController(IRoleRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var role = _repository.GetAll();
        return Ok(role);
    }

    [HttpGet("{guid}")]
    public IActionResult GetByGuid(Guid guid)
    {
        var role = _repository.GetByGuid(guid);
        if (role is null)
        {
            return NotFound();
        }

        return Ok(role);
    }

    [HttpPost]
    public IActionResult Create(Role role)
    {
        var createrole = _repository.Create(role);
        return Ok(createrole);
    }

    [HttpPut]
    public IActionResult Update(Role role)
    {
        var isUpdate = _repository.Update(role);
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
    }*/
