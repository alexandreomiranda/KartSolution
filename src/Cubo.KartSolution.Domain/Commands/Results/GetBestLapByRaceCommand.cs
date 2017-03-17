using System;
using System.ComponentModel.DataAnnotations;

namespace Cubo.KartSolution.Domain.Commands.Results
{
    public class GetBestLapByRaceCommand
    {
        public string PilotName { get; set; }
        public int LapNumber { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = @"{0:mm\:ss\.fff}")]
        public TimeSpan BestTimeRace { get; set; }
    }
}
