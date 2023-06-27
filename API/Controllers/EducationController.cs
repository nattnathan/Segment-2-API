using API.Contracts;
using API.DTOs.Education;
using API.Models;
using API.Services;
using API.Utilities;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers;

[ApiController]
[Route("api/educations")]

public class EducationController : ControllerBase
{
    private readonly EducationService _service;

    public EducationController(EducationService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var educations = _service.GetEducation();
        if (educations == null)
        {
            return NotFound(new ResponseHandler<GetEducationDto>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Data Not Found"

            });
        }

        return Ok(new ResponseHandler<IEnumerable<GetEducationDto>>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "All Data Found",
            Data = educations
        });
    }

    [HttpGet("{guid}")]
    public IActionResult GetByGuid(Guid guid)
    {
        var education = _service.GetEducation(guid);
        if (education is null)
        {
            return NotFound(new ResponseHandler<GetEducationDto>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Data not found"
            });
        }

        return Ok(new ResponseHandler<GetEducationDto>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Data found",
            Data = education
        });
    }

    [HttpPost]
    public IActionResult Create(GetEducationDto newEmployeDto)
    {
        var createdEducation = _service.CreateEducation(newEmployeDto);
        if (createdEducation is null)
        {
            return BadRequest(new ResponseHandler<GetEducationDto>
            {
                Code = StatusCodes.Status400BadRequest,
                Status = HttpStatusCode.BadRequest.ToString(),
                Message = "Data not created"
            });
        }

        return Ok(new ResponseHandler<GetEducationDto>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Successfully created",
            Data = createdEducation
        });
    }

    [HttpPut]
    public IActionResult Update(GetEducationDto updateEmployeeDto)
    {
        var update = _service.UpdateEducation(updateEmployeeDto);
        if (update is -1)
        {
            return NotFound(new ResponseHandler<GetEducationDto>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Id not found"
            });
        }
        if (update is 0)
        {
            return BadRequest(new ResponseHandler<GetEducationDto>
            {
                Code = StatusCodes.Status500InternalServerError,
                Status = HttpStatusCode.InternalServerError.ToString(),
                Message = "Check your data"
            });
        }
        return Ok(new ResponseHandler<GetEducationDto>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Successfully updated"
        });
    }

    [HttpDelete]
    public IActionResult Delete(Guid guid)
    {
        var delete = _service.DeleteEducation(guid);

        if (delete is -1)
        {
            return NotFound(new ResponseHandler<GetEducationDto>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Id not found"
            });
        }
        if (delete is 0)
        {
            return BadRequest(new ResponseHandler<GetEducationDto>
            {
                Code = StatusCodes.Status500InternalServerError,
                Status = HttpStatusCode.InternalServerError.ToString(),
                Message = "Check connection to database"
            });
        }

        return Ok(new ResponseHandler<GetEducationDto>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Successfully deleted"
        });
    }
}
















/*private readonly IEducationRepository _repository;
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
    }*/
