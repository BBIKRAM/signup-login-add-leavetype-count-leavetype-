using BikramApi.Modeels;
using Microsoft.EntityFrameworkCore;

namespace BikramApi.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }
        public DbSet<User> tbl_user { get; set; }
    }
}
