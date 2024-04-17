using LogsFinaktiva.Domain.Enums;
using LogsFinaktiva.Service.Common;
using LogsFinaktiva.Service.DTO;

namespace LogsFinaktiva.Service.Interfaces
{
    public interface IEventLogService
    {
        Task<ServiceResponse<EventLogDto>> CreateEventLogAsync(EventLogCreateDto eventLogCreate);
        Task<ServiceResponse<List<EventLogDto>>> GetEventLogAsync();
        Task<ServiceResponse<List<EventLogDto>>> GetEventLogForDateAsync(DateTime startdate, DateTime endDate);
        Task<ServiceResponse<List<EventLogDto>>> GetEventLogForTypeAsync(EEventType typeEvent);
    }
}
