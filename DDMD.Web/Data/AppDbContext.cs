using Microsoft.EntityFrameworkCore;
using DDMD.Web.Models;

namespace DDMD.Web.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Post> Posts => Set<Post>();
    }
}
