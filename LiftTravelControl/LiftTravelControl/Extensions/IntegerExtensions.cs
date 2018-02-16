namespace LiftTravelControl.Extensions
{
    public static class IntegerExtensions
    {
        public static bool IsValidFloor(this int currentFloor, int min, int max)
        {
            return currentFloor >= min && currentFloor <= max;
        }
        public static bool Between(this int value, int lowerBoundary, int upperBoudnary, bool inclusive = true)
        {
            return inclusive
                ? lowerBoundary <= value && value <= upperBoudnary
                : lowerBoundary < value && value < upperBoudnary;
        }
    }
}
