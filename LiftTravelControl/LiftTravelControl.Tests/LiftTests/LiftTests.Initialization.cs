using LiftTravelControl.Interfaces;
using Xunit;

namespace LiftTravelControl.Tests
{
    public partial class LiftTests
    {
        [Fact]
        public void Lift_CanaryTest()
        {
            FloorConfiguration floorConfig = new FloorConfiguration(3, 0, 15);

            ILift lift = new Lift(floorConfig);

            Assert.Equal(floorConfig.CurrentFloor, lift.CurrentFloor);
        }

    }
}
