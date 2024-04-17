using AutoMapper;
using LogsFinaktiva.Service.Common;
using Microsoft.AspNetCore.Http;

namespace LogsFinaktiva.Service
{
    public class BaseService
    {
        protected readonly IMapper _mapper;
        protected readonly ILoggerManager _logger;
        protected readonly IHttpContextAccessor _httpContext;
        public BaseService(IMapper mapper, ILoggerManager loggerManager, IHttpContextAccessor httpContext)
        {
            _mapper = mapper;
            _logger = loggerManager;
            _httpContext = httpContext;
        }
    }
}
