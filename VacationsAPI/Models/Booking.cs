using System.ComponentModel.DataAnnotations;
using VacationsAPI.Common;
using VacationsAPI.Models.Common;

namespace VacationsAPI.Models
{
    public class Booking : BaseModel
    {
        public Booking()
        {
            this.Id = Guid.NewGuid().ToString();
            this.CreatedOn = DateTime.UtcNow;
            this.Status = BookingStatus.WaitingForApproval;
        }

        //public string UserId { get; set; }

        //public virtual User User { get; set; }

        public string BookingTypeId { get; set; }

        public virtual BookingType BookingType { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int Duration { get; set; }

        [MaxLength(300)]
        public string Comment { get; set; }

        public BookingStatus Status { get; set; }
    }
}
