using API.Utilities.Enums;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs.Booking;

public class NewBookingDto
{
    [Required]
    public DateTime StartDate { get; set; }

    [Required]
    public DateTime EndDate { get; set; }

    public string? Remarks { get; set; }

    [Required]
    [Range(0,4, ErrorMessage = "Request = 0, Reject = 1, UpComing = 2, OnGoing = 3, Done = 4 ")]
    public StatusLevel Status { get; set; }

    [Required]
    public Guid RoomGuid { get; set; }

    [Required]
    public Guid EmployeeGuid { get; set; }
}
