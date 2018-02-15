namespace LiftTravelControl.Interfaces
{
    public interface IFloorConfiguration
    {
        int CurrentFloor { get; }
        int MinFloor { get; }
        int MaxFloor { get; }
    }
}
