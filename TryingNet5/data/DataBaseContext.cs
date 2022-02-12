using Microsoft.EntityFrameworkCore;

namespace TryingNet5.data
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Country>().HasData(
                new Country()
                {
                    Id = 1,
                    Name = "Tunisia",
                    ShortName = "TN"
                },
                new Country()
                {
                    Id = 2,
                    Name = "France",
                    ShortName = "FR"
                },
                new Country()
                {
                    Id = 3,
                    Name = "Algeria",
                    ShortName = "DZ"
                }
                );
            builder.Entity<Hotel>().HasData(
                new Hotel()
                {
                    Id = 1,
                    Address = "address hotel 1",
                    CountryId = 1,
                    Name = "hotel 1",
                    Rating = 2
                }
                );
        }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
    }
}
