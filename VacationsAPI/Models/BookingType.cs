using VacationsAPI.Models.Common;

namespace VacationsAPI.Models
{
    public class BookingType : BaseModel
    {
        public BookingType()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Name { get; set; }

        public bool IsPaidTimeOff { get; set; }

        public bool IsSubtractDaysLeft { get; set; }

        public List<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
