using CampusGuidebook.Models;
using Microsoft.EntityFrameworkCore;

namespace CampusGuidebook.Data

{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


        public DbSet<EventsModel> EventTable { get; set; }
        public DbSet<EventConditions> EventConditions { get; set; }

    }
}
