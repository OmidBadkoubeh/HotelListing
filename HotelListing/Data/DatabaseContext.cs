using Microsoft.EntityFrameworkCore;

namespace HotelListing.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Country>().HasData(
                new Country
                {
                    Id = 1,
                    Name = "Iran",
                    ShortName = "IR"
                },
                new Country
                {
                    Id = 2,
                    Name = "United States",
                    ShortName = "US"
                },
                new Country
                {
                    Id = 3,
                    Name = "Netherlands",
                    ShortName = "NL"
                }
            );
            
            builder.Entity<Hotel>().HasData(
                new Hotel
                {
                    Id = 1,
                    Name = "Hotel Tehran",
                    Address = "Tehran, Valiasr Blvd.",
                    CountryId = 1,
                    Rating = 4
                },
                new Hotel
                {
                    Id = 2,
                    Name = "Hotel Parsian",
                    Address = "US, Valiasr Blvd.",
                    CountryId = 2,
                    Rating = 3.5
                },
                new Hotel
                {
                    Id = 3,
                    Name = "Hotel Holland",
                    Address = "Netherlands, Valiasr Blvd.",
                    CountryId = 3,
                    Rating = 5
                }
            );
        }

        public DbSet<Country> Countries { get; set; }
        
        public DbSet<Hotel> Hotels { get; set; }
        
    }
}