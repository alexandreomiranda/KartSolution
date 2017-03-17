using Cubo.KartSolution.Domain.Commands.Results;
using Cubo.KartSolution.Domain.Entities;
using Cubo.KartSolution.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cubo.KartSolution.Infra.Repositories
{
    public class RaceRepository : IRaceRepository
    {

        public IEnumerable<GetRaceResultCommand> GetRaceResult()
        {
            var dataRace = DataParser.Parse();
            var list = (from t in dataRace
                        group t by new { t.PilotCode } into g
                        let TimePilot = g.Aggregate(new TimeSpan(), (sum, nextData) => sum.Add(nextData.TimeLap))
                        let TimeWinner = ( from t in dataRace group t by new { t.PilotCode } into k
                                            select new { 
                                                PilotWin = k.Aggregate(new TimeSpan(), (sum, nextData) => sum.Add(nextData.TimeLap)), 
                                                TotalVoltas = k.Last().LapNumber 
                                            }).OrderBy(k => k.PilotWin).OrderByDescending(k => k.TotalVoltas)
                        select new GetRaceResultCommand()
                        {
                            PilotName = g.FirstOrDefault().PilotName,
                            PilotCode = g.Key.PilotCode,
                            TotalLaps = g.Last().LapNumber,
                            TotalProofTime = TimePilot,
                            DiffToFirst = TimePilot - TimeWinner.First().PilotWin

                        }).OrderBy(g => g.TotalProofTime).OrderByDescending(g => g.TotalLaps);
            return list;
        }

        public IEnumerable<GetAverageSpeedRaceByPilotCommand> GetAverageSpeedRaceByPilot()
        {
            var dataRace = DataParser.Parse();
            var list = dataRace.GroupBy(x => x.PilotCode)
                            .Select(x => new GetAverageSpeedRaceByPilotCommand
                            {
                                PilotName = x.FirstOrDefault().PilotName,
                                PilotCode = x.Key,
                                AverageSpeedRace = Math.Round(x.Average(p => p.AverageLapSpeed), 3)
                            });
            return list;
        }

        public IEnumerable<GetBestLapByPilotCommand> GetBestLapByPilot()
        {
            var dataRace = DataParser.Parse();
            var list = dataRace.GroupBy(x => x.PilotCode)
                            .Select(x => new GetBestLapByPilotCommand
                            {
                                PilotCode = x.Key,
                                PilotName = x.FirstOrDefault().PilotName,
                                BestTimeLap = x.Min(p => p.TimeLap)
                            }).OrderBy(x => x.BestTimeLap);
            return list;
        }

        public GetBestLapByRaceCommand GetBestLapByRace()
        {
            var dataRace = DataParser.Parse();
            var obj = dataRace.Select(x => new GetBestLapByRaceCommand
            {
                PilotName = x.PilotName,
                LapNumber = x.LapNumber,
                BestTimeRace = x.TimeLap
            }).OrderBy(x => x.BestTimeRace).First();
            return obj;
        }

        public IEnumerable<Race> GetLog()
        {
            return DataParser.Parse();
        }
    }
}
