using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LogsFinaktiva.Service.DTO.Enum
{
    public enum EEventTypeDto
    {
        [EnumMember(Value = "Api")] Api,
        [EnumMember(Value = "Formulario de eventos manuales")] From,
    }
}
