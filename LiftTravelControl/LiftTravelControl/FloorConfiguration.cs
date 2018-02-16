using LiftTravelControl.Exceptions;
using LiftTravelControl.Extensions;
using LiftTravelControl.Interfaces;
using System;
using LiftTravelControl.Enum;

namespace LiftTravelControl
{
    public class FloorConfiguration: IFloorConfiguration
    {
        public int CurrentFloor { get; private set; }
        public int MinFloor { get; private set; }
        public int MaxFloor { get; private set; }

        public FloorConfiguration(int currentFloor, int lowestFloor, int highestFloor)
        {
            Initialize(currentFloor, lowestFloor, highestFloor);
        }
        private void Initialize(int currentFloor, int lowestFloor, int highestFloor)
        {
            if (lowestFloor >= highestFloor)
            {
                throw new ArgumentException("ground floor is higher than top floor");
            }

            if (!currentFloor.IsValidFloor(lowestFloor, highestFloor))
            {
                throw new UnknowFloorExecption(currentFloor);
            }

            CurrentFloor = currentFloor;
            MinFloor = lowestFloor;
            MaxFloor = highestFloor;
        }

        public Boundaries GetBoundariesForDirection(TravelDirection direction)
        {
            return direction == TravelDirection.Up
                ? new Boundaries(CurrentFloor, MaxFloor)
                : new Boundaries(MinFloor, CurrentFloor);
        }

        internal Boundaries GetFullRangeBoundariesForDirection(TravelDirection direction)
        {
            return direction == TravelDirection.Up
                ? new Boundaries(MinFloor, MaxFloor)
                : new Boundaries(MinFloor, MaxFloor);
        }
    }
}
