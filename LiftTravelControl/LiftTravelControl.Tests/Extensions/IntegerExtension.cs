using LiftTravelControl.Extensions;
using Xunit;

namespace LiftTravelControl.Tests.Extensions
{
    public class IntegerExtension
    {
        [Fact]
        public void IntegerExtension_IsValidFloorMustReturnFalse_WhenValueIsOutsideBoundariesProvided()
        {
            int value = 3;
            value.IsValidFloor(6, 15);
        }
        [Fact]
        public void IntegerExtension_IsValidFloorMustReturnTrue_WhenValueIsInBoundariesProvided()
        {
            int value = 3;
            value.IsValidFloor(0, 15);
        }
    }
}
