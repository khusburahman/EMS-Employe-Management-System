using Microsoft.EntityFrameworkCore;
using EMS.webapp.Models;

namespace EMS.webapp.DatabaseContext;

public class ApplicationDbContext(DbContextOptions options) : DbContext(options)

{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }

public DbSet<EMS.webapp.Models.Employe> Employe { get; set; } = default!;
}
