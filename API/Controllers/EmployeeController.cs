using API.Contracts;
using API.Models;
using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/Employees")]
public class EmployeeController : GeneralController<Employee>
{
    public EmployeeController(IEmployeeRepository repository) : base(repository) { }
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