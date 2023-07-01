using API.Contracts;
using API.DTOs.Booking;
using API.DTOs.Rooms;
using API.Models;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Components.Forms;

namespace API.Services;

public class BookingService
{
    private readonly IBookingRepository _bookingRepository;
    private readonly IRoomRepository _roomRepository;

    public BookingService(IBookingRepository bookingRepository,
                          IRoomRepository roomRepository)
    {
        _bookingRepository = bookingRepository;
        _roomRepository = roomRepository;
    }

    public IEnumerable<GetBookingDto>? Getbooking()
    {
        var bookings = _bookingRepository.GetAll();
        if (!bookings.Any())
        {
            return null;
        }

        var toDto = bookings.Select(booking => new GetBookingDto
        {
            Guid = booking.Guid,
            StartDate = booking.StartDate,
            EndDate = booking.EndDate,
            Status = booking.Status,
            Remarks = booking.Remarks,
            RoomGuid = booking.RoomGuid,
            EmployeeGuid = booking.EmployeeGuid

        });

        return toDto;
    }

    public GetBookingDto? Getbooking(Guid guid)
    {
        var booking = _bookingRepository.GetByGuid(guid);
        if (booking is null)
        {
            return null;
        }

        var toDto = new GetBookingDto
        {
            Guid = booking.Guid,
            StartDate = booking.StartDate,
            EndDate = booking.EndDate,
            Status = booking.Status,
            Remarks = booking.Remarks,
            RoomGuid = booking.RoomGuid,
            EmployeeGuid = booking.EmployeeGuid
        };

        return toDto;
    }

    public GetBookingDto? Createbooking(NewBookingDto newbookingDto)
    {
        var booking = new Booking
        {
            Guid = new Guid(),
            StartDate = newbookingDto.StartDate,
            EndDate = newbookingDto.EndDate,
            Status = newbookingDto.Status,
            Remarks = newbookingDto.Remarks,
            RoomGuid = newbookingDto.RoomGuid,
            EmployeeGuid = newbookingDto.EmployeeGuid,
            CreatedDate = DateTime.Now,
            ModifiedDate = DateTime.Now
        };

        var createdbooking = _bookingRepository.Create(booking);
        if (createdbooking is null)
        {
            return null;
        }

        var toDto = new GetBookingDto
        {
            Guid = createdbooking.Guid,
            StartDate = newbookingDto.StartDate,
            EndDate = newbookingDto.EndDate,
            Status = newbookingDto.Status,
            Remarks = newbookingDto.Remarks,
            RoomGuid = newbookingDto.RoomGuid,
            EmployeeGuid = newbookingDto.EmployeeGuid,
        };

        return toDto;

    }

    public int Updatebooking(GetBookingDto updatebookingDto)
    {
        var isExist = _bookingRepository.IsExist(updatebookingDto.Guid);
        if (!isExist)
        {
            return -1; // Not Found
        }

        var getbooking = _bookingRepository.GetByGuid(updatebookingDto.Guid);
        var booking = new Booking
        {
            Guid = updatebookingDto.Guid,
            StartDate = updatebookingDto.StartDate,
            EndDate = updatebookingDto.EndDate,
            Status = updatebookingDto.Status,
            Remarks = updatebookingDto.Remarks,
            RoomGuid = updatebookingDto.RoomGuid,
            EmployeeGuid = updatebookingDto.EmployeeGuid,
            ModifiedDate = DateTime.Now,
            CreatedDate = getbooking!.CreatedDate
        };

        var isUpdate = _bookingRepository.Update(booking);
        if (!isUpdate)
        {
            return 0;
        }

        return 1;
    }

    public int Deletebooking(Guid guid)
    {
        var isExist = _bookingRepository.IsExist(guid);
        if (!isExist)
        {
            return -1; 
        }

        var booking = _bookingRepository.GetByGuid(guid);
        var isDelete = _bookingRepository.Delete(booking!);
        if (!isDelete)
        {
            return 0; // 
        }

        return 1;
    }

    public IEnumerable<BookingLengthDto> BookingDuration()
    {
        var bookings = _bookingRepository.GetAll();
        var rooms = _roomRepository.GetAll();

        var entities = (from booking in bookings
                        join room in rooms on booking.RoomGuid equals room.Guid
                        select new
                        {
                            guid = room.Guid,
                            startDate = booking.StartDate,
                            endDate = booking.EndDate,
                            roomName = room.Name
                        }).ToList();

        var bookingDurations = new List<BookingLengthDto>();

        foreach (var entity in entities)
        {
            TimeSpan duration = entity.endDate - entity.startDate;

            // Count the number of weekends within the duration
            int totalDays = (int)duration.TotalDays;
            int weekends = 0;

            for (int i = 0; i <= totalDays; i++)
            {
                var currentDate = entity.startDate.AddDays(i);
                if (currentDate.DayOfWeek == DayOfWeek.Saturday || currentDate.DayOfWeek == DayOfWeek.Sunday)
                {
                    weekends++;
                }
            }

            // Calculate the duration without weekends
            TimeSpan bookingLength = duration - TimeSpan.FromDays(weekends);

            var bookingDurationDto = new BookingLengthDto
            {
                RoomGuid = entity.guid,
                RoomName = entity.roomName,
                BookingLength = bookingLength
            };

            bookingDurations.Add(bookingDurationDto);
        }

        return bookingDurations;
    }

    public List<BookingDetailsDto>? GetBookingDetais()
    {
        var booking = _bookingRepository.GetBookingDetails();
        var bookingDetails = booking.Select(b => new BookingDetailsDto
        {
            Guid = b.Guid,
            BookedNik = b.BookedNik,
            BookedBy = b.BookedBy,
            RoomName = b.RoomName,
            StartDate = b.StartDate,
            EndDate = b.EndDate,
            Status = b.Status,
            Remarks = b.Remarks
        }).ToList();

        return bookingDetails;
    }

    public BookingDetailsDto GetBookingDetailsByGuid(Guid guid)
    {
        var relatedBooking = GetBookingDetais().SingleOrDefault(b => b.Guid == guid);
        return relatedBooking;
    }
}
