﻿namespace API.DTOs.Booking
{
    public class BookingLengthDto
    {
        public Guid RoomGuid { get; set; }
        public string RoomName { get; set;}
        public TimeSpan BookingLength { get; set;}

    }
}
