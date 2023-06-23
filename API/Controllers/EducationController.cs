using API.Contracts;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/Education")]

public class EducationController : ControllerBase
{
    private readonly IEducationRepository _repository;
    public EducationController(IEducationRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var education = _repository.GetAll();
        return Ok(education);
    }

    [HttpGet("{guid}")]
    public IActionResult GetByGuid(Guid guid)
    {
        var education = _repository.GetByGuid(guid);
        if(education is null)
        {
            return NotFound();
        }

        return Ok(education);
    }

    [HttpPost]
    public IActionResult Create(Education education)
    {
        var createEducation = _repository.Create(education);
        return Ok(createEducation);
    }

    [HttpPut]
    public IActionResult Update(Education education)
    {
        var isUpdate = _repository.Update(education);
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
