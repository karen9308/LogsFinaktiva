using LogsFinaktiva.Domain.Entities;
using LogsFinaktiva.Domain.Enums;

namespace LogsFinaktiva.Domain.Interfaces.Repositories
{
    public interface IEventLogRepository : IGenericRepository<EventLog>
    {
        Task<List<EventLog>> GetEventLogForDateAsync(DateTime StartDate, DateTime EndDate);
        Task<List<EventLog>> GetEventLogForTypeAsync(EEventType typeEvent);
    }
}
