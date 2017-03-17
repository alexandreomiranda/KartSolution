using System;
using System.ComponentModel.DataAnnotations;

namespace Cubo.KartSolution.Domain.Commands.Results
{
    public class GetRaceResultCommand
    {
        public int Position { get; set; }
        public int PilotCode { get; set; }
        public string PilotName { get; set; }
        public int TotalLaps { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = @"{0:mm\:ss\.fff}")]
        public TimeSpan TotalProofTime { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = @"{0:mm\:ss\.fff}")]
        public TimeSpan DiffToFirst { get; set; }
    }
}
