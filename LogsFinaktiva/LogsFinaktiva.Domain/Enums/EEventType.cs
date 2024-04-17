using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LogsFinaktiva.Domain.Enums
{
    public enum EEventType
    {
        [EnumMember(Value = "Api")] Api,
        [EnumMember(Value = "Formulario de eventos manuales")] From,
    }
}
