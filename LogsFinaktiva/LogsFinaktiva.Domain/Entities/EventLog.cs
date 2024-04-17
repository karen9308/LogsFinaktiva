using LogsFinaktiva.Domain.Common;
using LogsFinaktiva.Domain.Enums;

namespace LogsFinaktiva.Domain.Entities
{
    public class EventLog : Auditable
    {
        public string Event { get; set; }
        public EEventType Type { get; set; }
        public string Observation { get; set; }
        public DateTime EventDate { get; set; }
    }
}
