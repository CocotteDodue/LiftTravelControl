using LiftTravelControl.Interfaces;
using LiftTravelControl.Enum;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace LiftTravelControl.Tests.LiftTests
{
    public partial class LiftTests
    {
        [Fact]
        public void Lift_CreateExecutionPlan2Values_WhenParkedAndSummonedOnCurrentFloorForHigherFloor()
        {
            FloorConfiguration floorConfig = new FloorConfiguration(0, 0, 15);
            IExecutionPlan plan = new ExecutionPlan();
            ILift lift = new Lift(floorConfig, plan);
            SummonInformation summon = new SummonInformation(0, TravelDirection.Up);
            SummonInformation request = new SummonInformation(5, TravelDirection.None, summon);
            IList<SummonInformation> requests = new List<SummonInformation>()
            {
                summon,
                request
            };

            var executionPlan = lift.ProcessRequests(requests);

            var planResult = executionPlan.GetFloorVisitationPlan();
            Assert.Equal(2, planResult.Count());
            Assert.Equal(summon.SummonFloor, planResult.First());
            Assert.Equal(request.SummonFloor, planResult.Last());
        }

        [Fact]
        public void Lift_CreateExecutionPlanWith2Values_WhenParkedAndSummonedOnCurrentFloorForLowerFloor()
        {
            FloorConfiguration floorConfig = new FloorConfiguration(3, 0, 15);
            IExecutionPlan plan = new ExecutionPlan();
            ILift lift = new Lift(floorConfig, plan);
            SummonInformation summon = new SummonInformation(3, TravelDirection.Down);
            SummonInformation request = new SummonInformation(1, TravelDirection.None, summon);
            IList<SummonInformation> requests = new List<SummonInformation>()
            {
                summon,
                request
            };

            var executionPlan = lift.ProcessRequests(requests);

            var planResult = executionPlan.GetFloorVisitationPlan();
            Assert.Equal(2, planResult.Count());
            Assert.Equal(summon.SummonFloor, planResult.First());
            Assert.Equal(request.SummonFloor, planResult.Last());
        }

        [Fact]
        public void Lift_CreateExecutionPlanWith2Values_WhenParkedOnLowerFloorAndSummonToGoUp()
        {
            FloorConfiguration floorConfig = new FloorConfiguration(0, 0, 15);
            IExecutionPlan plan = new ExecutionPlan();
            ILift lift = new Lift(floorConfig, plan);
            SummonInformation summon = new SummonInformation(1, TravelDirection.Up);
            SummonInformation request = new SummonInformation(5, TravelDirection.None, summon);
            IList<SummonInformation> requests = new List<SummonInformation>()
            {
                summon,
                request
            };

            var executionPlan = lift.ProcessRequests(requests);

            var planResult = executionPlan.GetFloorVisitationPlan();
            Assert.Equal(2, planResult.Count());
        }

        [Fact]
        public void ExecutionPlan_HasSummonAndDesitnationInOrder_WhenParkedOnLowerFloorAndSummonToGoUp()
        {
            FloorConfiguration floorConfig = new FloorConfiguration(0, 0, 15);
            IExecutionPlan plan = new ExecutionPlan();
            ILift lift = new Lift(floorConfig, plan);
            SummonInformation summon = new SummonInformation(1, TravelDirection.Up);
            SummonInformation request = new SummonInformation(5, TravelDirection.None, summon);
            IList<SummonInformation> requests = new List<SummonInformation>()
            {
                summon,
                request
            };

            var executionPlan = lift.ProcessRequests(requests);

            var planResult = executionPlan.GetFloorVisitationPlan();
            Assert.Equal(summon.SummonFloor, planResult.First());
            Assert.Equal(request.SummonFloor, planResult.Last());
        }

        [Fact]
        public void Lift_CreateExecutionPlanWith2Values_WhenParkedOnHigherFloorAndSummonToGoDown()
        {
            FloorConfiguration floorConfig = new FloorConfiguration(4, 0, 15);
            IExecutionPlan plan = new ExecutionPlan();
            ILift lift = new Lift(floorConfig, plan);
            SummonInformation summon = new SummonInformation(3, TravelDirection.Down);
            SummonInformation request = new SummonInformation(2, TravelDirection.None, summon);
            IList<SummonInformation> requests = new List<SummonInformation>()
            {
                summon,
                request
            };

            var executionPlan = lift.ProcessRequests(requests);

            var planResult = executionPlan.GetFloorVisitationPlan();
            Assert.Equal(2, planResult.Count());
        }

        [Fact]
        public void ExecutionPlan_HasSummonAndDesitnationInOrder_WhenParkedOnHigherFloorAndSummonToGoDown()
        {
            FloorConfiguration floorConfig = new FloorConfiguration(4, 0, 15);
            IExecutionPlan plan = new ExecutionPlan();
            ILift lift = new Lift(floorConfig, plan);
            SummonInformation summon = new SummonInformation(3, TravelDirection.Down);
            SummonInformation request = new SummonInformation(2, TravelDirection.None, summon);
            IList<SummonInformation> requests = new List<SummonInformation>()
            {
                summon,
                request
            };

            var executionPlan = lift.ProcessRequests(requests);

            var planResult = executionPlan.GetFloorVisitationPlan();
            Assert.Equal(summon.SummonFloor, planResult.First());
            Assert.Equal(request.SummonFloor, planResult.Last());
        }

        [Fact]
        public void Lift_CreateExecutionPlanWith2Values_WhenParkedOnHigherFloorAndSummonToGoUp()
        {
            FloorConfiguration floorConfig = new FloorConfiguration(6, 0, 15);
            IExecutionPlan plan = new ExecutionPlan();
            ILift lift = new Lift(floorConfig, plan);
            SummonInformation summon = new SummonInformation(3, TravelDirection.Up);
            SummonInformation request = new SummonInformation(4, TravelDirection.None, summon);
            IList<SummonInformation> requests = new List<SummonInformation>()
            {
                summon,
                request
            };

            var executionPlan = lift.ProcessRequests(requests);

            var planResult = executionPlan.GetFloorVisitationPlan();
            Assert.Equal(2, planResult.Count());
        }

        [Fact]
        public void ExecutionPlan_HasSummonAndDesitnationInOrder_WhenParkedOnHigherFloorAndSummonToGoUp()
        {
            FloorConfiguration floorConfig = new FloorConfiguration(6, 0, 15);
            IExecutionPlan plan = new ExecutionPlan();
            ILift lift = new Lift(floorConfig, plan);
            SummonInformation summon = new SummonInformation(3, TravelDirection.Up);
            SummonInformation request = new SummonInformation(4, TravelDirection.None, summon);
            IList<SummonInformation> requests = new List<SummonInformation>()
            {
                summon,
                request
            };

            var executionPlan = lift.ProcessRequests(requests);

            var planResult = executionPlan.GetFloorVisitationPlan();
            Assert.Equal(summon.SummonFloor, planResult.First());
            Assert.Equal(request.SummonFloor, planResult.Last());
        }

        [Fact]
        public void Lift_CreateExecutionPlanWith2Values_WhenParkedOnLowerFloorAndSummonToGoDown()
        {
            FloorConfiguration floorConfig = new FloorConfiguration(2, 0, 15);
            IExecutionPlan plan = new ExecutionPlan();
            ILift lift = new Lift(floorConfig, plan);
            SummonInformation summon = new SummonInformation(3, TravelDirection.Down);
            SummonInformation request = new SummonInformation(1, TravelDirection.None, summon);
            IList<SummonInformation> requests = new List<SummonInformation>()
            {
                summon,
                request
            };

            var executionPlan = lift.ProcessRequests(requests);

            var planResult = executionPlan.GetFloorVisitationPlan();
            Assert.Equal(2, planResult.Count());
        }

        [Fact]
        public void ExecutionPlan_HasSummonAndDesitnationInOrder_WhenParkedOnLowerFloorAndSummonToGoDown()
        {
            FloorConfiguration floorConfig = new FloorConfiguration(2, 0, 15);
            IExecutionPlan plan = new ExecutionPlan();
            ILift lift = new Lift(floorConfig, plan);
            SummonInformation summon = new SummonInformation(3, TravelDirection.Down);
            SummonInformation request = new SummonInformation(1, TravelDirection.None, summon);
            IList<SummonInformation> requests = new List<SummonInformation>()
            {
                summon,
                request
            };

            var executionPlan = lift.ProcessRequests(requests);

            var planResult = executionPlan.GetFloorVisitationPlan();
            Assert.Equal(summon.SummonFloor, planResult.First());
            Assert.Equal(request.SummonFloor, planResult.Last());
        }
    }
}
