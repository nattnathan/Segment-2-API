using API.Contracts;
using API.DTOs.Booking;
using API.Models;

namespace API.Services
{
    public class BookingService
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingService(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
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
    }
}
