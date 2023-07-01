using System.ComponentModel;
using API.Contracts;
using API.Data;
using API.DTOs.Booking;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories;

public class BookingRepository : GeneralRepository<Booking>, IBookingRepository
{
    public BookingRepository(BookingDbContext context) : base(context)
    {
    }

    public IEnumerable<BookingDetailsDto> GetBookingDetails()
    {
        var booking = _context.Bookings
            .Include(b => b.Room)
            .Include(b => b.Employee)
            .Where(b => b.Room.Guid == b.Room.Guid && b.Employee.Guid == b.Employee.Guid)
            .ToList();

        var bookingDetails = booking.Select(b => new BookingDetailsDto
        {
            Guid = b.Guid,
            BookedNik = b.Employee.Nik,
            BookedBy = b.Employee.FirstName + " " + b.Employee.LastName,
            RoomName = b.Room.Name,
            StartDate = b.StartDate,
            EndDate = b.EndDate,
            Status = b.Status,
            Remarks = b.Remarks
        });
        return bookingDetails;
    }
}



















/*// Class untuk Menghubungkan Controler Ke Models
public class BookingRepository : IBookingRepository
{
    private readonly BookingDbContext _context;

    public BookingRepository(BookingDbContext context)
    {
        _context = context;
    }

    public ICollection<Booking> GetAll()
    {
        return _context.Set<Booking>().ToList();
    }

    public Booking? GetByGuid(Guid guid)
    {
        return _context.Set<Booking>().Find(guid);
    }

    public Booking Create(Booking booking)
    {
        try
        {
            _context.Set<Booking>().Add(booking);
            _context.SaveChanges();

            return booking;
        }
        catch
        {
            return new Booking();
        }
    }

    public bool Update(Booking booking)
    {
        try
        {
            _context.Set<Booking>().Update(booking);
            _context.SaveChanges();

            return true;
        }
        catch 
        {
            return false;
        }
    }

    public bool Delete(Guid guid)
    {
        try
        {
            var booking = GetByGuid(guid);
            if (booking is null)
            {
                return false; ;
            }

            _context.Set<Booking>().Remove(booking);
            _context.SaveChanges();

            return true;
        }
        catch 
        {
            return false; ;
        }
    }
}*/
