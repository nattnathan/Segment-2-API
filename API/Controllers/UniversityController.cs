using API.Contracts;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/Universities")]

 public class UniversityController : GeneralController<University>
 {
    public UniversityController(IUniversityRepository repository) : base(repository) { } 
 }
















/*private readonly IUniversityRepository _repository;

    public UniversityController(IUniversityRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var universities = _repository.GetAll();
        if (!universities.Any())
        {
            return NotFound();
        }

        return Ok(universities);
    }

    [HttpGet("{guid}")]
    public IActionResult GetByGuid(Guid guid)
    {
        var university = _repository.GetByGuid(guid);
        if (university is null)
        {
            return NotFound();
        }

        return Ok(university);
    }

    [HttpPost]
    public IActionResult Create(University university)
    {
        var createUniversity = _repository.Create(university);
        return Ok(createUniversity);
    }

    [HttpPut]
    public IActionResult Update(University university)
    {
        var isUpdate = _repository.Update(university);
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