using LiftTravelControl.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace LiftTravelControl
{
    public class Boundaries : Tuple<int, int>
    {
        public Boundaries(int item1, int item2) : base(item1, item2)
        {
        }

        public int GetExtremumForDirection(TravelDirection direction)
        {
            return direction == TravelDirection.Up
                            ? Item2
                            : Item1;
        }

        public bool IsExtremum (TravelDirection direction, int value)
        {
            return value == GetExtremumForDirection(direction);
        }

        public override bool Equals(object obj)
        {
            Boundaries objAsBoundary = (Boundaries)obj;
            if (objAsBoundary == null)
            {
                return false;
            }
            return Item1 == objAsBoundary.Item1 
                    && Item2 == objAsBoundary.Item2;
        }
    }
}
