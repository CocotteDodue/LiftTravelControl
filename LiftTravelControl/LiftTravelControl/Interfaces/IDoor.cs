using LiftTravelControl.Pocos;

namespace LiftTravelControl.Interfaces
{
    public interface IDoor
    {
        DoorState CurrentState { get; }
    }
}
