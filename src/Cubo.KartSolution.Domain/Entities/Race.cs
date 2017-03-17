using System;

namespace Cubo.KartSolution.Domain.Entities
{
    public class Race
    {
        public Race(DateTime datetimeLap, int pilotCode, string pilotName, int lapNumber, TimeSpan timeLap, decimal averageLapSpeed)
        {
            DatetimeLap = datetimeLap;
            PilotCode = pilotCode;
            PilotName = pilotName;
            LapNumber = lapNumber;
            TimeLap = timeLap;
            AverageLapSpeed = averageLapSpeed;
        }

        public DateTime DatetimeLap { get; private set; }
        public int PilotCode { get; private set; }
        public string PilotName { get; private set; }
        public int LapNumber { get; private set; }
        public TimeSpan TimeLap { get; private set; }
        public decimal AverageLapSpeed { get; private set; }
    }
}
