using System;
using System.Linq;

namespace LiftTravelControl
{
    public class Program
    {
        private const int liftMinFloor = 1;
        private const int liftMaxFloor = 10;

        private const int liftMinFloor0Based = liftMinFloor - 1;
        private const int liftMaxFloor0Based = liftMaxFloor - 1;

        public static void Main(string[] args)
        {
            if (args == null
               || !args.Any())
            {
                throw new ArgumentException("Missing lift floor parameter");
            }

            int currentParkedFloorValue = GetCurrentFloorValue(args);

            if (!IsValidFloor(currentParkedFloorValue))
            {
                throw new ArgumentException($"Unknown floor value: {currentParkedFloorValue}");
            }
        }

        private static bool IsValidFloor(int currentParkedFloorValue)
        {
            return currentParkedFloorValue >= liftMinFloor && currentParkedFloorValue <= liftMaxFloor;
        }

        private static int GetCurrentFloorValue(string[] args)
        {
            int currentParkedFloorValue;
            bool isNumberFloorValue = int.TryParse(args.First(), out currentParkedFloorValue);

            if (!isNumberFloorValue)
            {
                throw new ArgumentException($"Invalid floor value: {args.First()}");
            }

            return currentParkedFloorValue;
        }
    }
}
