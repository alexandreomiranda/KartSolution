using Cubo.KartSolution.Domain.Commands.Results;
using Cubo.KartSolution.Domain.Entities;
using System.Collections.Generic;

namespace Cubo.KartSolution.Domain.Repositories
{
    public interface IRaceRepository
    {
        IEnumerable<GetRaceResultCommand> GetRaceResult();
        IEnumerable<GetAverageSpeedRaceByPilotCommand> GetAverageSpeedRaceByPilot();
        IEnumerable<GetBestLapByPilotCommand> GetBestLapByPilot();
        GetBestLapByRaceCommand GetBestLapByRace();
        IEnumerable<Race> GetLog();
    }
}
