using AutoMapper;
using LogsFinaktiva.Domain.Entities;
using LogsFinaktiva.Service.DTO;

namespace LogsFinaktiva.Service.AutoMapper
{
    public class EventLogProfile : Profile
    {
        public EventLogProfile()
        {
            CreateMap<EventLog, EventLogDto>().ReverseMap();
            CreateMap<EventLog, EventLogCreateDto>().ReverseMap();
        }
    }
}
