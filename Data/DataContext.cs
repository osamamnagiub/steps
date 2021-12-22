using ASP.NETCoreWebApplication.Model;
using Microsoft.EntityFrameworkCore;

namespace ASP.NETCoreWebApplication.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) :
            base(options)
        {
        }

        public DbSet<Step> Steps { get; set; }
        public DbSet<AppUser> Users { get; set; }

        public DbSet<Item> Items { get; set; }
    }
}