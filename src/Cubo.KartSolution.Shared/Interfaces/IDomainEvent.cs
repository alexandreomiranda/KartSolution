using System;

namespace Cubo.KartSolution.Shared.Interfaces
{
    public interface IDomainEvent
    {
        DateTime DateOccurred { get; }
    }
}
