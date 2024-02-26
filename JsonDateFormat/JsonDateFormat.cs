using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Converters;

namespace Agendamento
{
    public class JsonDateFormat : IsoDateTimeConverter
    {
        public JsonDateFormat()
        {
            JsonDateFormatConverter = "dd/MM/yyyy HH";
        }

        public string JsonDateFormatConverter { get; }
    }
}