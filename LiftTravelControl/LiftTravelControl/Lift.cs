using LiftTravelControl.Interfaces;

namespace LiftTravelControl
{
    public class Lift: ILift
    {
        public int CurrentFloor => _floorConfiguration.CurrentFloor;
        private FloorConfiguration _floorConfiguration;

        public Lift(FloorConfiguration floorConfiguration)
        {
            _floorConfiguration = floorConfiguration;
        }
    }
}
