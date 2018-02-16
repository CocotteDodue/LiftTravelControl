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
            FloorConfiguration floorConfig = new FloorConfiguration(0, 0, 15);
            IExecutionPlan plan = new ExecutionPlan();
            ILift lift = new Lift(floorConfig, plan);
            int destinationFloor = 5;
            IList<SummonInformation> requests = new List<SummonInformation>()
            {
                new SummonInformation(floorConfig.CurrentFloor, TravelDirection.Up),
                new SummonInformation(destinationFloor, TravelDirection.None)
            };

            var executionPlan = lift.ProcessRequests(requests);

            var planResult = executionPlan.GetPlan();
            Assert.Equal(1, planResult.Count());
            Assert.Equal(destinationFloor, planResult.First());
        }

        [Fact]
        public void Lift_CreateExecutionPlanWithSingleValue_WhenParkedAndSummonedOnCurrentFloorForLowerFloor()
        {
            FloorConfiguration floorConfig = new FloorConfiguration(3, 0, 15);
            IExecutionPlan plan = new ExecutionPlan();
            ILift lift = new Lift(floorConfig, plan);
            int destinationFloor = floorConfig.CurrentFloor - 1;
            IList<SummonInformation> requests = new List<SummonInformation>()
            {
                new SummonInformation(floorConfig.CurrentFloor, TravelDirection.Down),
                new SummonInformation(destinationFloor, TravelDirection.None)
            };

            var executionPlan = lift.ProcessRequests(requests);

            var planResult = executionPlan.GetPlan();
            Assert.Equal(1, planResult.Count());
            Assert.Equal(destinationFloor, planResult.First());
        }

        [Fact]
        public void Lift_CreateExecutionPlanWith2Values_WhenParkedOnLowerFloorAndSummonToGoUp()
        {
            FloorConfiguration floorConfig = new FloorConfiguration(0, 0, 15);
            IExecutionPlan plan = new ExecutionPlan();
            ILift lift = new Lift(floorConfig, plan);
            int summoningFloor = 1;
            int destinationFloor = 5;
            IList<SummonInformation> requests = new List<SummonInformation>()
            {
                new SummonInformation(summoningFloor, TravelDirection.Up),
                new SummonInformation(destinationFloor, TravelDirection.None)
            };

            var executionPlan = lift.ProcessRequests(requests);

            var planResult = executionPlan.GetPlan();
            Assert.Equal(2, planResult.Count());
            Assert.Equal(summoningFloor, planResult.First());
            Assert.Equal(destinationFloor, planResult.Last());
        }

        [Fact]
        public void ExecutionPlan_HasSummonAndDesitnationInOrder_WhenParkedOnLowerFloorAndSummonToGoUp()
        {
            FloorConfiguration floorConfig = new FloorConfiguration(0, 0, 15);
            IExecutionPlan plan = new ExecutionPlan();
            ILift lift = new Lift(floorConfig, plan);
            int summoningFloor = 1;
            int destinationFloor = 5;
            IList<SummonInformation> requests = new List<SummonInformation>()
            {
                new SummonInformation(summoningFloor, TravelDirection.Up),
                new SummonInformation(destinationFloor, TravelDirection.None)
            };

            var executionPlan = lift.ProcessRequests(requests);

            var planResult = executionPlan.GetPlan();
            Assert.Equal(2, planResult.Count());
            Assert.Equal(summoningFloor, planResult.First());
            Assert.Equal(destinationFloor, planResult.Last());
        }

        [Fact]
        public void Lift_CreateExecutionPlanWith2Values_WhenParkedOnHigherFloorAndSummonToGoDown()
        {
            FloorConfiguration floorConfig = new FloorConfiguration(4, 0, 15);
            IExecutionPlan plan = new ExecutionPlan();
            ILift lift = new Lift(floorConfig, plan);
            int summoningFloor = 3;
            int destinationFloor = 2;
            IList<SummonInformation> requests = new List<SummonInformation>()
            {
                new SummonInformation(summoningFloor, TravelDirection.Up),
                new SummonInformation(destinationFloor, TravelDirection.None)
            };

            var executionPlan = lift.ProcessRequests(requests);

            var planResult = executionPlan.GetPlan();
            Assert.Equal(2, planResult.Count());
            Assert.Equal(summoningFloor, planResult.First());
            Assert.Equal(destinationFloor, planResult.Last());
        }

        [Fact]
        public void ExecutionPlan_HasSummonAndDesitnationInOrder_WhenParkedOnHigherFloorAndSummonToGoDown()
        {
            FloorConfiguration floorConfig = new FloorConfiguration(4, 0, 15);
            IExecutionPlan plan = new ExecutionPlan();
            ILift lift = new Lift(floorConfig, plan);
            int summoningFloor = 3;
            int destinationFloor = 2;
            IList<SummonInformation> requests = new List<SummonInformation>()
            {
                new SummonInformation(summoningFloor, TravelDirection.Up),
                new SummonInformation(destinationFloor, TravelDirection.None)
            };

            var executionPlan = lift.ProcessRequests(requests);

            var planResult = executionPlan.GetPlan();
            Assert.Equal(2, planResult.Count());
            Assert.Equal(summoningFloor, planResult.First());
            Assert.Equal(destinationFloor, planResult.Last());
        }
    }
}
