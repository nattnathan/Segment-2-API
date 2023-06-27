using API.DTOs.Universities;
using API.Services;
using API.Utilities;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers;

[ApiController]
[Route("api/universities")]

 public class UniversityController : ControllerBase 
 {   
    private readonly UniversityService _service;

    public UniversityController(UniversityService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var universities = _service.GetUniversity();
        if (universities == null)
        {
            return NotFound(new ResponseHandler<GetUniversityDto>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Data Not Found"

            });
        }

        return Ok(new ResponseHandler<IEnumerable<GetUniversityDto>>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "All Data Found",
            Data = universities
        });
    }

    [HttpGet("{guid}")]
    public IActionResult GetByGuid(Guid guid)
    {
        var university = _service.GetUniversity(guid);
        if (university is null)
        {
            return NotFound(new ResponseHandler<GetUniversityDto>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Data not found"
            });
        }

        return Ok(new ResponseHandler<GetUniversityDto>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Data found",
            Data = university
        });
    }

    [HttpPost]
    public IActionResult Create(NewUniversityDto newUniversityDto)
    {
        var createdUniversity = _service.CreateUniversity(newUniversityDto);
        if (createdUniversity is null)
        {
            return BadRequest(new ResponseHandler<GetUniversityDto>
            {
                Code = StatusCodes.Status400BadRequest,
                Status = HttpStatusCode.BadRequest.ToString(),
                Message = "Data not created"
            });
        }

        return Ok(new ResponseHandler<GetUniversityDto>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Successfully created",
            Data = createdUniversity
        });
    }

    [HttpPut]
    public IActionResult Update(GetUniversityDto updateUniversityDto )
    {
        var update = _service.UpdateUniversity(updateUniversityDto);
        if (update is -1)
        {
            return NotFound(new ResponseHandler<GetUniversityDto>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Id not found"
            });
        }
        if (update is 0)
        {
            return BadRequest(new ResponseHandler<GetUniversityDto>
            {
                Code = StatusCodes.Status500InternalServerError,
                Status = HttpStatusCode.InternalServerError.ToString(),
                Message = "Check your data"
            });
        }
        return Ok(new ResponseHandler<GetUniversityDto>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Successfully updated"
        });
    }

    [HttpDelete]
    public IActionResult Delete(Guid guid)
    {
        var delete = _service.DeleteUniversity(guid);

        if (delete is -1)
        {
            return NotFound(new ResponseHandler<GetUniversityDto>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Id not found"
            });
        }
        if (delete is 0)
        {
            return BadRequest(new ResponseHandler<GetUniversityDto>
            {
                Code = StatusCodes.Status500InternalServerError,
                Status = HttpStatusCode.InternalServerError.ToString(),
                Message = "Check connection to database"
            });
        }

        return Ok(new ResponseHandler<GetUniversityDto>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Successfully deleted"
        });
    }

    [HttpGet("name/{name}")]
    public IActionResult GetByName(string name)
    {
        var university = _service.GetUniversity(name);
        if (!university.Any())
        {
            return NotFound(new ResponseHandler<GetUniversityDto>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Data By Name Not Found"
            });
        }

        return Ok(new ResponseHandler <IEnumerable <GetUniversityDto>>
            {
            Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Data By Name Found",
                Data = university
            });
    }
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