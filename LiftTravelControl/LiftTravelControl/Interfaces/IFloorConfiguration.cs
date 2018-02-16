using LiftTravelControl.Enum;
using System;

namespace LiftTravelControl.Interfaces
{
    public interface IFloorConfiguration
    {
        int CurrentFloor { get; }
        int MinFloor { get; }
        int MaxFloor { get; }

        Tuple<int, int> GetBoundariesForDirection(TravelDirection direction);
    }
}
