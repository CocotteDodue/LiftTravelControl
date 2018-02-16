using System.Collections.Generic;
using LiftTravelControl.Enum;

namespace LiftTravelControl.Interfaces
{
    public interface ILift
    {
        int CurrentFloor { get; }
        LiftState CurrentState { get; }

        IExecutionPlan ProcessRequests(IList<SummonInformation> requests);
    }
}
