using LogsFinaktiva.Service.DTO.Enum;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LogsFinaktiva.Service.DTO
{
    public class EventLogCreateDto
    {
        public Guid CreateRegisterByUserId { get; set; }
        public DateTime CreateRegisterDate { get; set; } = DateTime.Now;
        public string Event { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public EEventTypeDto Type { get; set; }
        public string Observation { get; set; }
        public DateTime EventDate { get; set; }

    }
}
