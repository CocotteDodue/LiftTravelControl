namespace LiftTravelControl.Pocos
{
    public class SummonInformation
    {
        public int SummonFloor { get; set; }
        public TravelDirection Direction { get; set; }

        public SummonInformation(int currentFloor, TravelDirection up)
        {
            SummonFloor = currentFloor;
            Direction = up;
        }
    }
}
