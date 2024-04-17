using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogsFinaktiva.Service.Common
{
    public class ServiceResponse<T> : BaseResponse where T : class
    {
        public T Entity { get; set; }

        private ServiceResponse(bool success, string message, T entity)
            : base(success, message)
        {
            Entity = entity;
        }

        public ServiceResponse(T entity) : this(true, string.Empty, entity) { }
        public ServiceResponse(string message) : this(false, message, null) { }
        public ServiceResponse(T entity, string message) : this(false, message, entity) { }
    }
}
