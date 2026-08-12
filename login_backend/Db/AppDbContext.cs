using login_backend.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace login_backend.Db
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }
        public DbSet<User> Users { get; set; }
    }
}
