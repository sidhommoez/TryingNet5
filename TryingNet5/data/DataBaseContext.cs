using Microsoft.EntityFrameworkCore;

namespace TryingNet5.data
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Country> Countries { get; set; }
    }
}
