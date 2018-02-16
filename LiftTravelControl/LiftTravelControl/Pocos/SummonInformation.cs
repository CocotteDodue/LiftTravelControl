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

        public override bool Equals(object obj)
        {
            SummonInformation summonInfo = (SummonInformation)obj;
            if (summonInfo == null)
            {
                return false;
            }
            return this.SummonFloor == summonInfo.SummonFloor
                && this.Direction == summonInfo.Direction;
        }

        public override int GetHashCode()
        {
            return SummonFloor + (int)Direction;
        }
    }
}
