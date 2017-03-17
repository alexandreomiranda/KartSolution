using System;
using System.ComponentModel.DataAnnotations;

namespace Cubo.KartSolution.Domain.Commands.Results
{
    public class GetBestLapByPilotCommand
    {
        public int PilotCode { get; set; }
        public string PilotName { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = @"{0:mm\:ss\.fff}")]
        public TimeSpan BestTimeLap { get; set; }
    }
}
