using API.DTOs.AccountRole;
using API.Services;
using API.Utilities;
using API.Utilities.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers;

[ApiController]
[Route("api/accountRoles")]
//[Authorize(Roles = $"{nameof(RoleLevel.Admin)}")]
public class AccountRoleController : ControllerBase
{
    private readonly AccountRoleService _service;

    public AccountRoleController(AccountRoleService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var accountRoles = _service.GetAccountRole();
        if (accountRoles == null)
        {
            return NotFound(new ResponseHandler<GetAccountRoleDto>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Data Not Found"

            });
        }

        return Ok(new ResponseHandler<IEnumerable<GetAccountRoleDto>>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "All Data Found",
            Data = accountRoles
        });
    }

    [HttpGet("{guid}")]
    public IActionResult GetByGuid(Guid guid)
    {
        var education = _service.GetAccountRole(guid);
        if (education is null)
        {
            return NotFound(new ResponseHandler<GetAccountRoleDto>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Data not found"
            });
        }

        return Ok(new ResponseHandler<GetAccountRoleDto>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Data found",
            Data = education
        });
    }

    [HttpPost]
    public IActionResult Create(NewAccountRoleDto newaccountRoledto)
    {
        var createdEducation = _service.CreateAccountRole(newaccountRoledto);
        if (createdEducation is null)
        {
            return BadRequest(new ResponseHandler<GetAccountRoleDto>
            {
                Code = StatusCodes.Status400BadRequest,
                Status = HttpStatusCode.BadRequest.ToString(),
                Message = "Data not created"
            });
        }

        return Ok(new ResponseHandler<GetAccountRoleDto>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Successfully created",
            Data = createdEducation
        });
    }

    [HttpPut]
    public IActionResult Update(GetAccountRoleDto updateaccountRoleDto)
    {
        var update = _service.UpdateAccountRole(updateaccountRoleDto);
        if (update is -1)
        {
            return NotFound(new ResponseHandler<GetAccountRoleDto>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Id not found"
            });
        }
        if (update is 0)
        {
            return BadRequest(new ResponseHandler<GetAccountRoleDto>
            {
                Code = StatusCodes.Status500InternalServerError,
                Status = HttpStatusCode.InternalServerError.ToString(),
                Message = "Check your data"
            });
        }
        return Ok(new ResponseHandler<GetAccountRoleDto>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Successfully updated"
        });
    }

    [HttpDelete]
    public IActionResult Delete(Guid guid)
    {
        var delete = _service.DeleteAccountRole(guid);

        if (delete is -1)
        {
            return NotFound(new ResponseHandler<GetAccountRoleDto>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Id not found"
            });
        }
        if (delete is 0)
        {
            return BadRequest(new ResponseHandler<GetAccountRoleDto>
            {
                Code = StatusCodes.Status500InternalServerError,
                Status = HttpStatusCode.InternalServerError.ToString(),
                Message = "Check connection to database"
            });
        }

        return Ok(new ResponseHandler<GetAccountRoleDto>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Successfully deleted"
        });
    }
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