
namespace Cubo.KartSolution.Domain.Commands.Results
{
    public class GetAverageSpeedRaceByPilotCommand
    {
        public int PilotCode { get; set; }
        public string PilotName { get; set; }
        public double AverageSpeedRace { get; set; }
    }
}
