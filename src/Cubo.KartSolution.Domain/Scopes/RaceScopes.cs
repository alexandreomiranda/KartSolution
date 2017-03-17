using Cubo.KartSolution.Domain.Entities;
using Cubo.KartSolution.Shared.Validation;

namespace Cubo.KartSolution.Domain.Scopes
{
    public static class RaceScopes
    {
        public static bool CreateRaceScopeIsValid(this Race race)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertIsGreaterThan(race.PilotCode, 0, "Código do piloto deve ser maior que zero"),
                AssertionConcern.AssertNotNullOrEmpty(race.PilotName, "Nome do piloto obrigatório"),
                AssertionConcern.AssertIsGreaterThan(race.LapNumber, 0, "Número da volta deve ser maior que zero")
            );
        }
    }
}
