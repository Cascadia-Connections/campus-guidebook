using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CampusGuidebook.Models;

namespace CampusGuidebook.Data;

public class EventInfoDBContext : DbContext
{
    public virtual DbSet<EventInfoModel> EventInfo { get; set; }
    public virtual DbSet<EventStatuses> EventStatuses { get; set; }

    public EventInfoDBContext()
    {

    }
    public EventInfoDBContext(DbContextOptions<EventInfoDBContext> options)
        : base(options)
    {
    }

}
