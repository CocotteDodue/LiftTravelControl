using System;

namespace LiftTravelControl.Exceptions
{
    public class UnknowFloorExecption : ArgumentException
    {
        public UnknowFloorExecption() :
            base($"Unknown floor value")
        { }

        public UnknowFloorExecption(int floor) :
            base($"Unknown floor value: {floor}")
        { }
    }
}
