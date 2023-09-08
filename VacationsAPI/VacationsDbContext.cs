using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using VacationsAPI.Models;

namespace VacationsAPI
{
    public class VacationsDbContext : DbContext
    {
        public VacationsDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Booking> Bookings { get; set; }

        public DbSet<BookingType> BookingTypes { get; set; }
    }
}
