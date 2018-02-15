using System.Collections.Generic;
using LiftTravelControl.Interfaces;
using LiftTravelControl.Pocos;

namespace LiftTravelControl
{
    public class Lift: ILift
    {
        public int CurrentFloor => _floorConfiguration.CurrentFloor;
        public LiftState CurrentState => _state;

        private FloorConfiguration _floorConfiguration;
        private LiftState _state = LiftState.Parked;

        public Lift(FloorConfiguration floorConfiguration)
        {
            _floorConfiguration = floorConfiguration;
        }

        IEnumerable<int> ILift.ProcessRequests(IEnumerable<SummonInformation> requests)
        {
            throw new System.NotImplementedException();
        }
    }
}
