using LogsFinaktiva.Service.DTO.Common;
using LogsFinaktiva.Service.DTO.Enum;
using Newtonsoft.Json.Converters;
using System.Text.Json.Serialization;

namespace LogsFinaktiva.Service.DTO
{
    public class EventLogDto : AuditableDto
    {
        public string Event { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public EEventTypeDto Type { get; set; }
        public string Observation { get; set; }
        public DateTime EventDate { get; set; }
    }
}
