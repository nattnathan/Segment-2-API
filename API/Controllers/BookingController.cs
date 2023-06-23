using API.Contracts;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/Bookings")]

public class BookingController : GeneralController<Booking>
{
    public BookingController(IBookingRepository repository) : base(repository) { }
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
