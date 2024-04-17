using LogsFinaktiva.Api.Extensions;
using LogsFinaktiva.Domain.Enums;
using LogsFinaktiva.Service.DTO;
using LogsFinaktiva.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LogsFinaktiva.Api.Controllers
{
    [ApiVersion("1.0")]
    [Route("[controller]")]
    [ApiController]
    public class EventLogController : Controller
    {
        private readonly IEventLogService _eventLogService;
        public EventLogController(IEventLogService eventLogService)
        {
            _eventLogService = eventLogService; ;
        }

        [HttpPost]
        public async Task<IActionResult> CreateEventLogAsync([FromBody] EventLogCreateDto eventLog)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var result = await _eventLogService.CreateEventLogAsync(eventLog);

            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(result);
        }
        [HttpGet("EventLogs")]
        public async Task<IActionResult> GetEventLogAsync()
        {
            var result = await _eventLogService.GetEventLogAsync();

            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(result.Entity);
        }
        [HttpGet("EventLogsDate")]
        public async Task<IActionResult> GetEventLogForDateAsync(DateTime startdate, DateTime endDate)
        {
            var result = await _eventLogService.GetEventLogForDateAsync(startdate, endDate);

            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(result.Entity);
        }
        [HttpGet("EventLogType")]
        public async Task<IActionResult> GetEventLogForTypeAsync(EEventType typeEvent)
        {
            var result = await _eventLogService.GetEventLogForTypeAsync(typeEvent);

            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(result.Entity);
        }

    }
}
