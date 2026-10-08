using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telemetry
{
    static class TelemetryParser
    {
        //string line = "M2024;Opportunity;2023.11.01;220;Igaz";
        public static TelemetryRecord ParseLine(string line)
        {
            if (string.IsNullOrWhiteSpace(line)){ 
                throw new ArgumentNullException("Üres a sor!"); 
            }else{
                TelemetryRecord record = new TelemetryRecord();
                string[] sorReszek = line.Split(';');
                record.Id = sorReszek[0];
                record.Rovername = sorReszek[1];
                record.Date = DateOnly.Parse(sorReszek[2]);
                record.Distance = int.Parse(sorReszek[3]);
                if (sorReszek[4] == "Igaz")
                {
                    record.IsSuccessful = true;
                }
                else { record.IsSuccessful = false; }
                return record;
            }
        }
    }
}
