using API.Contracts;
using API.DTOs.Employee;
using API.Models;
using API.Services;
using API.Utilities;
using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers;

[ApiController]
[Route("api/employees")]
public class EmployeeController : ControllerBase
{
    private readonly EmployeeService _service;

    public EmployeeController(EmployeeService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var employees = _service.GetEmployee();
        if (employees is null)
        {
            return NotFound(new ResponseHandler<GetEmployeeDto>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Data Not Found"

            });
        }

        return Ok(new ResponseHandler<IEnumerable<GetEmployeeDto>>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "All Data Found",
            Data = employees
        });
    }

    [HttpGet("{guid}")]
    public IActionResult GetByGuid(Guid guid)
    {
        var employee = _service.GetEmployee(guid);
        if (employee is null)
        {
            return NotFound(new ResponseHandler<GetEmployeeDto>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Data not found"
            });
        }

        return Ok(new ResponseHandler<GetEmployeeDto>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Data found",
            Data = employee
        });
    }

    [HttpPost]
    public IActionResult Create(NewEmployeDto newEmployeDto)
    {
        var createdEmployee = _service.CreateEmployee(newEmployeDto);
        if (createdEmployee is null)
        {
            return BadRequest(new ResponseHandler<GetEmployeeDto>
            {
                Code = StatusCodes.Status400BadRequest,
                Status = HttpStatusCode.BadRequest.ToString(),
                Message = "Data not created"
            });
        }

        return Ok(new ResponseHandler<GetEmployeeDto>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Successfully created",
            Data = createdEmployee
        });
    }

    [HttpPut]
    public IActionResult Update(GetEmployeeDto updateEmployeeDto)
    {
        var update = _service.UpdateEmploye(updateEmployeeDto);
        if (update is -1)
        {
            return NotFound(new ResponseHandler<GetEmployeeDto>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Id not found"
            });
        }
        if (update is 0)
        {
            return BadRequest(new ResponseHandler<GetEmployeeDto>
            {
                Code = StatusCodes.Status500InternalServerError,
                Status = HttpStatusCode.InternalServerError.ToString(),
                Message = "Check your data"
            });
        }
        return Ok(new ResponseHandler<GetEmployeeDto>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Successfully updated"
        });
    }

    [HttpDelete]
    public IActionResult Delete(Guid guid)
    {
        var delete = _service.DeleteEmployee(guid);

        if (delete is -1)
        {
            return NotFound(new ResponseHandler<GetEmployeeDto>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Id not found"
            });
        }
        if (delete is 0)
        {
            return BadRequest(new ResponseHandler<GetEmployeeDto>
            {
                Code = StatusCodes.Status500InternalServerError,
                Status = HttpStatusCode.InternalServerError.ToString(),
                Message = "Check connection to database"
            });
        }

        return Ok(new ResponseHandler<GetEmployeeDto>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Successfully deleted"
        });
    }

    [HttpGet("name/{firstName}")]
    public IActionResult GetByFirstName(string firstName)
    {
        var employee = _service.GetEmploye(firstName);
        if (employee == null)
        {
            return NotFound(new ResponseHandler<GetEmployeeDto>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Data By Name Not Found"
            });
        }

        return Ok(new ResponseHandler <IEnumerable <GetEmployeeDto>>
            {
            Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Data By Name Found",
                Data = employee
            });
    }
}














/*private readonly IEmployeeRepository _repository;
    public EmployeeController(IEmployeeRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var employee = _repository.GetAll();
        if (!employee.Any())
        {
            return NotFound();
        }

        return Ok(employee);
    }

    [HttpGet("{guid}")]
    public IActionResult GetByGuid(Guid guid)
    {
        var employee = _repository.GetByGuid(guid);
        if(employee is null)
        {
            return NotFound();
        }

        return Ok(employee);
    }

    [HttpPost]
    public IActionResult Create(Employee employee)
    {
        var createEmployee = _repository.Create(employee);
        return Ok(createEmployee);
    }

    [HttpPut]
    public IActionResult Update(Employee employee)
    {
        var isUpdate = _repository.Update(employee);
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