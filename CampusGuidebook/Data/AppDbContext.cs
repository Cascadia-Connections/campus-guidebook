using Microsoft.EntityFrameworkCore;

namespace CampusGuidebook.Data

{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
           : base(options)
        {
        }

    }
}
