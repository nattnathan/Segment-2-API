using API.Contracts;
using API.DTOs.Roles;
using API.Models;
using API.Services;
using API.Utilities;
using API.Utilities.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Net;
namespace API.Controllers;

[ApiController]
[Route("api/roles")]
//[Authorize(Roles = $"{nameof(RoleLevel.Admin)}")]
public class RoleController : ControllerBase
{
    private readonly RoleService _service;

    public RoleController(RoleService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var roles = _service.GetRole();
        if (roles == null)
        {
            return NotFound(new ResponseHandler<GetRoleDto>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Data Not Found"
            });
        }

        return Ok(new ResponseHandler<IEnumerable<GetRoleDto>>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "All Data Found",
            Data = roles
        });
    }

    [HttpGet("{guid}")]
    public IActionResult GetByGuid(Guid guid)
    {
        var role = _service.GetRole(guid);
        if (role is null)
        {
            return NotFound(new ResponseHandler<GetRoleDto>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Data not found"
            });
        }

        return Ok(new ResponseHandler<GetRoleDto>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Data found",
            Data = role
        });
    }

    [HttpPost]
    public IActionResult Create(NewRoleDto newRoleDto)
    {
        var createdRole = _service.CreateRole(newRoleDto);
        if (createdRole is null)
        {
            return BadRequest(new ResponseHandler<GetRoleDto>
            {
                Code = StatusCodes.Status400BadRequest,
                Status = HttpStatusCode.BadRequest.ToString(),
                Message = "Data not created"
            });
        }

        return Ok(new ResponseHandler<GetRoleDto>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Successfully created",
            Data = createdRole
        });
    }

    [HttpPut]
    public IActionResult Update(GetRoleDto updateRoleDto)
    {
        var update = _service.UpdateRole(updateRoleDto);
        if (update is -1)
        {
            return NotFound(new ResponseHandler<GetRoleDto>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Id not found"
            });
        }
        if (update is 0)
        {
            return BadRequest(new ResponseHandler<GetRoleDto>
            {
                Code = StatusCodes.Status500InternalServerError,
                Status = HttpStatusCode.InternalServerError.ToString(),
                Message = "Check your data"
            });
        }
        return Ok(new ResponseHandler<GetRoleDto>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Successfully updated"
        });
    }

    [HttpDelete]
    public IActionResult Delete(Guid guid)
    {
        var delete = _service.DeleteRole(guid);

        if (delete is -1)
        {
            return NotFound(new ResponseHandler<GetRoleDto>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Id not found"
            });
        }
        if (delete is 0)
        {
            return BadRequest(new ResponseHandler<GetRoleDto>
            {
                Code = StatusCodes.Status500InternalServerError,
                Status = HttpStatusCode.InternalServerError.ToString(),
                Message = "Check connection to database"
            });
        }

        return Ok(new ResponseHandler<GetRoleDto>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Successfully deleted"
        });
    }

    /*[HttpGet("name/{name}")]
    public IActionResult GetByName(string name)
    {
        var role = _service.GetRole(name);
        if (!role.Any())
        {
            return NotFound(new ResponseHandler<GetRoleDto>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Data By Name Not Found"
            });
        }

        return Ok(new ResponseHandler<GetRoleDto>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Data By Name Found",
            Data = role
        });
    }*/
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
