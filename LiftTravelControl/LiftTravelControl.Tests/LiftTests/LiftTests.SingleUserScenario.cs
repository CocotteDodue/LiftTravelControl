using LiftTravelControl.Interfaces;
using LiftTravelControl.Pocos;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace LiftTravelControl.Tests.LiftTests
{
    public partial class LiftTests
    {
        [Fact]
        public void Lift_CreateExecutionPlanWithSingleValue_WhenParkedAndSummonedOnCurrentFloorForHigherFloor()
        {
            FloorConfiguration floorConfig = new FloorConfiguration(3, 0, 15);
            ILift lift = new Lift(floorConfig);
            IEnumerable<SummonInformation> requests = new List<SummonInformation>()
            {
                new SummonInformation(floorConfig.CurrentFloor, TravelDirection.Up),
                new SummonInformation(floorConfig.CurrentFloor + 1, TravelDirection.None)
            };

            var executionPlan = lift.ProcessRequests(requests);

            Assert.Equal(1, executionPlan.Count());
        }
    }
}
