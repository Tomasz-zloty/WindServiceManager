using Microsoft.EntityFrameworkCore;
using WindServiceManager.Models;

namespace WindServiceManager.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<WindTurbine> WindTurbines { get; set; }
    public DbSet<ServiceTicket> ServiceTickets { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ServiceTicket>()
            .HasOne(t => t.WindTurbine)
            .WithMany(w => w.ServiceTickets)
            .HasForeignKey(t => t.WindTurbineId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
