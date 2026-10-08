using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telemetry
{
    internal class TelemetryRecord
    {
        public string Id { get; set; }
        public string Rovername { get; set; }
        public DateOnly Date { get; set; }
        public int Distance { get; set; }
        public bool IsSuccessful { get; set; }
    }
}
