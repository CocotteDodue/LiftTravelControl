using System.Collections.Generic;
using LiftTravelControl.Pocos;

namespace LiftTravelControl.Interfaces
{
    public interface ILift
    {
        int CurrentFloor { get; }
        LiftState CurrentState { get; }

        IEnumerable<int> ProcessRequests(IEnumerable<SummonInformation> requests);
    }
}
