using LiftTravelControl.Interfaces;

namespace LiftTravelControl
{
    public class Door: IDoor
    {
        private DoorState _doorState = DoorState.Close;

        public DoorState CurrentState => _doorState;
    }
}
