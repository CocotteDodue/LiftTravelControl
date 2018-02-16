using LiftTravelControl.Interfaces;
using Xunit;

namespace LiftTravelControl.Tests.LiftTests
{
    public partial class LiftTests
    {
        [Fact]
        public void Lift_CanaryTest()
        {
            FloorConfiguration floorConfig = new FloorConfiguration(3, 0, 15);
            IExecutionPlan plan = new ExecutionPlan();

            ILift lift = new Lift(floorConfig, plan);

            Assert.NotNull(lift);
            Assert.Equal(floorConfig.CurrentFloor, lift.CurrentFloor);
        }

    }
}
