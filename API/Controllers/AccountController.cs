using API.Contracts;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/Accounts")]

public class AccountController : GeneralController<Account>
{
    public AccountController(IAccountRepository repository) : base(repository) { }
}

















/*private readonly IAccountRepository _repository;
    public AccountController(IAccountRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var account = _repository.GetAll();
        return Ok(account);
    }

    [HttpGet("{guid}")]
    public IActionResult GetByGuid(Guid guid)
    {
        var account = _repository.GetByGuid(guid);
        if(account is null)
        {
            return NotFound();
        }

        return Ok(account);
    }

    [HttpPost]
    public IActionResult Create(Account account)
    {
        var crateAccount = _repository.Create(account);
        return Ok(crateAccount);
    }

    [HttpPut]
    public IActionResult Update(Account account)
    {
        var isUpdate = _repository.Update(account);
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
