using AutoMapper;
using LogsFinaktiva.Domain.Entities;
using LogsFinaktiva.Domain.Enums;
using LogsFinaktiva.Domain.Interfaces;
using LogsFinaktiva.Service.Common;
using LogsFinaktiva.Service.DTO;
using LogsFinaktiva.Service.Interfaces;
using Microsoft.AspNetCore.Http;

namespace LogsFinaktiva.Service
{
    public class EventLogService : BaseService, IEventLogService
    {
        private readonly IUnitOfWork _unitOfWork;
        public EventLogService(IMapper mapper, ILoggerManager loggerManager, IHttpContextAccessor httpContext, IUnitOfWork unitOfWork) : base(mapper, loggerManager, httpContext)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ServiceResponse<EventLogDto>> CreateEventLogAsync(EventLogCreateDto AwardCreate)
        {
            try
            {
                EventLog EventLogEntity = _mapper.Map<EventLog>(AwardCreate);

                if (EventLogEntity == null)
                    throw new ArgumentException("EventLog or a required property is null");

                EventLogEntity.CreateRegisterDate = DateTime.Now;

                _unitOfWork.BeginTransaction();
                _unitOfWork.EventLogRepository.Create(EventLogEntity);
                await _unitOfWork.CommitAsync();

                return new ServiceResponse<EventLogDto>(_mapper.Map<EventLogDto>(EventLogEntity))
                { Message = "Datos insertados correctamente" };
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in EventLogService::CreateAsync:: {ex.Message} ");
                throw;
            }
        }

        public async Task<ServiceResponse<List<EventLogDto>>> GetEventLogAsync()
        {
            try
            {
                var eventLogs = await _unitOfWork.EventLogRepository.GetAllAsync();

                var eventLogsDTO = _mapper.Map<List<EventLogDto>>(eventLogs);

                return new ServiceResponse<List<EventLogDto>>(eventLogsDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in EventLogService::GetEventLogAsync:: {ex.Message} ");
                throw;
            }
        }

        public async Task<ServiceResponse<List<EventLogDto>>> GetEventLogForDateAsync(DateTime stardate, DateTime endDate)
        {
            try
            {
                var paymentRequests = await _unitOfWork.EventLogRepository.GetEventLogForDateAsync(stardate,endDate);

                return new ServiceResponse<List<EventLogDto>>(_mapper.Map<List<EventLogDto>>(paymentRequests));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in EventLogService::GetEventLogForDateAsync:: {ex.Message} ");
                return new ServiceResponse<List<EventLogDto>>($"EventLogService::GetEventLogForDateAsync:: {ex.Message}");
            }
        }
        public async Task<ServiceResponse<List<EventLogDto>>> GetEventLogForTypeAsync(EEventType typeEvent)
        {
            try
            {
                var paymentRequests = await _unitOfWork.EventLogRepository.GetEventLogForTypeAsync(typeEvent);

                return new ServiceResponse<List<EventLogDto>>(_mapper.Map<List<EventLogDto>>(paymentRequests));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in EventLogService::GetEventLogForTypeAsync:: {ex.Message} ");
                return new ServiceResponse<List<EventLogDto>>($"EventLogService::GetEventLogForTypeAsync:: {ex.Message}");
            }
        }


    }
}
