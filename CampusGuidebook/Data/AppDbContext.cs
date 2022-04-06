using CampusGuidebook.Models;
using Microsoft.EntityFrameworkCore;

namespace CampusGuidebook.Data

{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }



        public DbSet<EventsModel> _Db { get; set; }

    }
}
