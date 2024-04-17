using LogsFinaktiva.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogsFinaktiva.Infraestructure.Data.Configurations
{
    public class EventLogConfiguration
    {
        public void Configure(EntityTypeBuilder<EventLog> builder)
        {
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(d => d.CreateRegisterDate).HasDefaultValueSql("getdate()");
        }
    }
}
