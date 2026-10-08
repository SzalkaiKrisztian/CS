using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telemetry
{
    internal class TelemetryService
    {
        //public TelemetryService()
        //{

        //}

        //1
        public int GetTotalMeasurementCount(List<TelemetryRecord> records) 
        { 
            if(records.Count == 0 || records == null) {  return 0; } else { return records.Count; }
        }

        //2
        public int GetTotalDistance(List<TelemetryRecord> records)
        {
            int totalDistance = 0;
            if (records.Count == 0 || records == null) { return 0; }
            else
            {
                for (int i = 0; i < records.Count; i++)
                {
                    records[i].Distance += totalDistance;
                }
                return totalDistance;
            }  
        }

        //3
        public TelemetryRecord? GetLongestDailyDistanceRecord(List<TelemetryRecord> records)
        {
            TelemetryRecord longestDistance = records[0];
            if (records.Count == 0 || records == null) { return null; }
            else
            {
                for(int i = 0;i < records.Count; i++)
                {
                    if (records[i].Distance > longestDistance.Distance) 
                    { 
                        longestDistance = records[i]; 
                    }
                }
                return longestDistance;
            }
        }

        //4
        public int GetSuccessfulMissionCountByRover(List<TelemetryRecord> records, string roverName)
        {
            int successfulMissionCount = 0;
            int i = 0;
            while (i < records.Count)
            {
                if (records[i].Rovername == roverName)
                {
                    for(int j=0; j < records.Count; j++)
                    {
                        if (records[j].IsSuccessful == true)
                        {
                            successfulMissionCount++;
                        }
                    }
                }
                else { i++; }
            }
            if (i >= records.Count) { throw new KeyNotFoundException(roverName); }
            return successfulMissionCount;
        }

        //5
        public Dictionary<string, int> GetMeasurementCountPerRover(List<TelemetryRecord> records)
        {
            Dictionary<string, int> roverKuldetesek = new Dictionary<string, int>();
            for(int i = 0; i < records.Count; i++)
            {
                if (roverKuldetesek.ContainsKey(records[i].Rovername))
                {
                    roverKuldetesek[records[i].Rovername]++;
                }
                else
                {
                    roverKuldetesek[records[i].Rovername]=1;
                }
            }
            return roverKuldetesek;
        }

        //6
        public List<TelemetryRecord> GetSuccessfulRecords(List<TelemetryRecord> records)
        {
            List<TelemetryRecord> wins = new List<TelemetryRecord>();
            for (int i = 0; i < records.Count; i++)
            {
                if (records[i].IsSuccessful)
                {
                    wins.Add(records[i]);
                }
            }
            return wins;
        }
    }
}
