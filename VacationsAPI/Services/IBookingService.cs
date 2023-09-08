using VacationsAPI.Models;

namespace VacationsAPI.Services
{
    public interface IBookingService
    {
        Task<Booking> GetBookingById(string id);

        Task<IEnumerable<TViewModel>> GetMyBookings<TViewModel>(); 

        Task<IEnumerable<TViewModel>> GetMyTeamBookings<TViewModel>(); // For Manager role

        Task<bool> Create(Booking bookingModel);

        Task<Booking> GetBookingForApprove(string bookingId);

        Task SetBookingStatus(string bookingId);
    }
}
