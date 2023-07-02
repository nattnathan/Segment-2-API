using API.Utilities.Enums;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs.Booking;

public class BookingDetailsDto
{
    public Guid Guid {get; set; }
    public string BookedNik { get; set; }
    public string BookedBy { get; set; }
    public string RoomName { get; set; }
    public DateTime StartDate {get; set; }
    public DateTime EndDate { get; set; }
    public StatusLevel Status { get; set; }
    public string Remarks { get; set; }
}

