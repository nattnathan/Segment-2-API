using API.DTOs.Booking;
using API.DTOs.Rooms;
using API.Services;
using API.Utilities;
using API.Utilities.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers;

[ApiController]
[Route("api/bookings")]
//[Authorize(Roles = $"{nameof(RoleLevel.Admin)}")]
public class BookingController : ControllerBase
{
    private readonly BookingService _service;

    public BookingController(BookingService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var bookings = _service.Getbooking();
        if (bookings == null)
        {
            return NotFound(new ResponseHandler<GetBookingDto>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Data Not Found"

            });
        }

        return Ok(new ResponseHandler<IEnumerable<GetBookingDto>>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "All Data Found",
            Data = bookings
        });
    }

    [HttpGet("{guid}")]
    public IActionResult GetByGuid(Guid guid)
    {
        var education = _service.Getbooking(guid);
        if (education is null)
        {
            return NotFound(new ResponseHandler<GetBookingDto>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Data not found"
            });
        }

        return Ok(new ResponseHandler<GetBookingDto>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Data found",
            Data = education
        });
    }

    [HttpPost]
    public IActionResult Create(NewBookingDto newBookingdto)
    {
        var createdEducation = _service.Createbooking(newBookingdto);
        if (createdEducation is null)
        {
            return BadRequest(new ResponseHandler<GetBookingDto>
            {
                Code = StatusCodes.Status400BadRequest,
                Status = HttpStatusCode.BadRequest.ToString(),
                Message = "Data not created"
            });
        }

        return Ok(new ResponseHandler<GetBookingDto>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Successfully created",
            Data = createdEducation
        });
    }

    [HttpPut]
    public IActionResult Update(GetBookingDto updateBookingDto)
    {
        var update = _service.Updatebooking(updateBookingDto);
        if (update is -1)
        {
            return NotFound(new ResponseHandler<GetBookingDto>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Id not found"
            });
        }
        if (update is 0)
        {
            return BadRequest(new ResponseHandler<GetBookingDto>
            {
                Code = StatusCodes.Status500InternalServerError,
                Status = HttpStatusCode.InternalServerError.ToString(),
                Message = "Check your data"
            });
        }
        return Ok(new ResponseHandler<GetBookingDto>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Successfully updated"
        });
    }

    [HttpDelete]
    public IActionResult Delete(Guid guid)
    {
        var delete = _service.Deletebooking(guid);

        if (delete is -1)
        {
            return NotFound(new ResponseHandler<GetBookingDto>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Id not found"
            });
        }
        if (delete is 0)
        {
            return BadRequest(new ResponseHandler<GetBookingDto>
            {
                Code = StatusCodes.Status500InternalServerError,
                Status = HttpStatusCode.InternalServerError.ToString(),
                Message = "Check connection to database"
            });
        }

        return Ok(new ResponseHandler<GetBookingDto>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Successfully deleted"
        });
    }

    [Route("bookingsLength")]
    [HttpGet]
    public IActionResult CalculateBookingLength()
    {
        var entities = _service.BookingDuration();
        if (entities == null || !entities.Any())
        {
            return NotFound(new ResponseHandler<BookingLengthDto>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Data not found"
            });
        }

        return Ok(new ResponseHandler<IEnumerable<BookingLengthDto>>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Data found",
            Data = entities
        });
    }

    [HttpGet("details")]
    public IActionResult GetBookingDetails()
    {
        var bookingDetails = _service.GetBookingDetais();
        if (bookingDetails == null)
        {
            return NotFound(new ResponseHandler<GetBookingDto>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Data Not Found"

            });
        }

        return Ok(new ResponseHandler<IEnumerable<BookingDetailsDto>>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "All Data Found",
            Data = bookingDetails
        });
    }

    [HttpGet("details-by-guid")]
    public IActionResult GetBookingByGuid(Guid guid)
    {
        var bookingDetailsGuid = _service.GetBookingDetailsByGuid(guid);
        if (bookingDetailsGuid == null)
        {
            return NotFound(new ResponseHandler<GetBookingDto>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Data Not Found"
            });

        }
        return Ok(new ResponseHandler<BookingDetailsDto>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "All Data Found",
            Data = bookingDetailsGuid
        });
    }

    [HttpGet("booking-today")]
    public IActionResult GetBookingToday()
    {
        var bookingDetailsGuid = _service.BookingToday();
        if (bookingDetailsGuid == null)
        {
            return NotFound(new ResponseHandler<GetBookingDto>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Data Not Found"
            });

        }
        return Ok(new ResponseHandler<IEnumerable<BookingTodayDto>>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "All Data Found",
            Data = bookingDetailsGuid
        });
    }
}

















/* private readonly IBookingRepository _repository;
    public BookingController(IBookingRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var booking = _repository.GetAll();
        return Ok(booking);
    }

    [HttpGet("{guid}")]
    public IActionResult GetByGuid(Guid guid)
    {
        var booking = _repository.GetByGuid(guid);
        if(booking is null)
        {
            return NotFound();
        }

        return Ok(booking);
    }

    [HttpPost]
    public IActionResult Create(Booking booking)
    {
        var createEducation = _repository.Create(booking);
        return Ok(createEducation);
    }

    [HttpPut]
    public IActionResult Update(Booking booking)
    {
        var isUpdate = _repository.Update(booking);
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
