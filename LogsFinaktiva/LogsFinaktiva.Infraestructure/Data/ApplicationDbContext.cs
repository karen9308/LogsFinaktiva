using LogsFinaktiva.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace LogsFinaktiva.Infraestructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<EventLog>? EventLogs { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(mb);
        }
    }
}
