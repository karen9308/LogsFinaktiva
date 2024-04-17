using LogsFinaktiva.Domain.Entities;
using LogsFinaktiva.Domain.Enums;
using LogsFinaktiva.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LogsFinaktiva.Infraestructure.Data.Repositories
{
    public class EventLogRepository : GenericRepository<EventLog>, IEventLogRepository
    {
        public EventLogRepository(ApplicationDbContext appDbContext) : base(appDbContext)
        { }

        public async Task<List<EventLog>> GetEventLogForDateAsync(DateTime StartDate, DateTime EndDate)
        {
            return await _appDbContext.EventLogs
                   .Where(p => p.EventDate >= StartDate && p.EventDate <= EndDate)
                   .ToListAsync();
        }

        public async Task<List<EventLog>> GetEventLogForTypeAsync(EEventType typeEvent)
        {
            return await _appDbContext.EventLogs
                  .Where(p => p.Type == typeEvent)
                  .ToListAsync();
        }
    }

       
    
}
