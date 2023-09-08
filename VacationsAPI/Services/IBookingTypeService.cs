using VacationsAPI.Models;

namespace VacationsAPI.Services
{
    public interface IBookingTypeService
    {
        Task<bool> AddBookingType(BookingType bookingTypeModel);

        Task<IEnumerable<string>> GetBookingTypes();
    }
}
