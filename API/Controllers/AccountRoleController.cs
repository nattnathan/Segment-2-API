using API.Contracts;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/AccountRoles")]

public class AccountRoleController : GeneralController<AccountRole>
{ 
    public AccountRoleController(IAccountRoleRepository repository) : base(repository) { }
}

















/*private readonly IAccountRoleRepository _repository;
    public AccountRoleController(IAccountRoleRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var accountRole = _repository.GetAll();
        return Ok(accountRole);
    }

    [HttpGet("{guid}")]
    public IActionResult GetByGuid(Guid guid)
    {
        var accountRole = _repository.GetByGuid(guid);
        if(accountRole is null)
        {
            return NotFound();
        }

        return Ok(accountRole);
    }

    [HttpPost]
    public IActionResult Create(AccountRole accountRole)
    {
        var createAccounRole = _repository.Create(accountRole);
        return Ok(createAccounRole);
    }

    [HttpPut]
    public IActionResult Update(AccountRole accountRole)
    {
        var isUpdate = _repository.Update(accountRole);
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