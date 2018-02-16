using LiftTravelControl.Enum;

namespace LiftTravelControl
{
    public class SummonInformation
    {
        public int F { set { SummonFloor = value; } }
        public TravelDirection D { set { Direction = value; } }
        public SummonInformation T { set { TriggeringSummon = value; } }
        public int SummonFloor { get; set; }
        public TravelDirection Direction { get; set; }
        public SummonInformation TriggeringSummon { get; set; }

        public SummonInformation(int currentFloor, TravelDirection direction = TravelDirection.None, SummonInformation triggeringSummon = null)
        {
            SummonFloor = currentFloor;
            Direction = direction;
            if (direction == TravelDirection.None)
            {
                TriggeringSummon = triggeringSummon;
            } else
            {
                TriggeringSummon = null;
            }
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
