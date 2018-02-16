using LiftTravelControl.Interfaces;
using LiftTravelControl.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;


namespace LiftTravelControl.Tests.LiftTests
{
    public partial class LiftTests
    {
        //Passenger 1 summons lift to go up from Ground.They choose L5.Passenger 2 summons lift to go down from L4.Passenger 3 summons lift to go down from L10.Passengers 2 and 3 choose to travel to Ground.
        [Fact]
        public void Lift_CreateExecutionPlanWith6Values_WhenSummonedFrom3FloorsTo2DifferentsFloors()
        {
            FloorConfiguration floorConfig = new FloorConfiguration(2, 0, 15);
            IExecutionPlan plan = new ExecutionPlan();
            ILift lift = new Lift(floorConfig, plan);
            SummonInformation summon1 = new SummonInformation(0, TravelDirection.Up);
            SummonInformation request1 = new SummonInformation(5, TravelDirection.None, summon1);
            SummonInformation summon2 = new SummonInformation(4, TravelDirection.Down);
            SummonInformation summon3 = new SummonInformation(10, TravelDirection.Down);
            SummonInformation request2 = new SummonInformation(0, TravelDirection.None, summon2);
            SummonInformation request3 = new SummonInformation(0, TravelDirection.None, summon3);
            IList<SummonInformation> requests = new List<SummonInformation>()
            {
                summon1,
                request1,
                summon2,
                summon3,
                request2,
                request3
            };

            var executionPlan = lift.ProcessRequests(requests);

            var planResult = executionPlan.GetFloorVisitationPlan();
            Assert.Equal(5, planResult.Count());
        }
        [Fact]
        public void ExecutionPlan_HasExpectedAscUpToMaxFloorThenDesc_WhenSummonedFrom3FloorsTo2DifferentsFloors()
        {
            FloorConfiguration floorConfig = new FloorConfiguration(2, 0, 15);
            IExecutionPlan plan = new ExecutionPlan();
            ILift lift = new Lift(floorConfig, plan);
            SummonInformation summon1 = new SummonInformation(0, TravelDirection.Up);
            SummonInformation request1 = new SummonInformation(5, TravelDirection.None, summon1);
            SummonInformation summon2 = new SummonInformation(4, TravelDirection.Down);
            SummonInformation summon3 = new SummonInformation(10, TravelDirection.Down);
            SummonInformation request2 = new SummonInformation(0, TravelDirection.None, summon2);
            SummonInformation request3 = new SummonInformation(0, TravelDirection.None, summon3);
            IList<SummonInformation> requests = new List<SummonInformation>()
            {
                summon1,
                request1,
                summon2,
                summon3,
                request2,
                request3
            };

            var executionPlan = lift.ProcessRequests(requests);

            var planResult = executionPlan.GetFloorVisitationPlan();
            Assert.Equal(summon1.SummonFloor, planResult.ElementAt(0));
            Assert.Equal(request1.SummonFloor, planResult.ElementAt(1));
            Assert.Equal(summon3.SummonFloor, planResult.ElementAt(2));
            Assert.Equal(summon2.SummonFloor, planResult.ElementAt(3));
            Assert.Equal(request2.SummonFloor, planResult.ElementAt(4));
        }

        //Parked:0 - Passenger 1 summons lift to go up from Ground.They choose L5.Passenger 2 summons lift to go down from L4.Passenger 3 summons lift to go down from L10.Passengers 2 goes to Ground and 3 choose to travel to L8.
        [Fact]
        public void Lift_CreateExecutionPlanWith6Values_WhenSummonedFrom3FloorsTo3DifferentsFloors()
        {
            FloorConfiguration floorConfig = new FloorConfiguration(0, 0, 15);
            IExecutionPlan plan = new ExecutionPlan();
            ILift lift = new Lift(floorConfig, plan);
            SummonInformation summon1 = new SummonInformation(0, TravelDirection.Up);
            SummonInformation request1 = new SummonInformation(5, TravelDirection.None, summon1);
            SummonInformation summon2 = new SummonInformation(4, TravelDirection.Down);
            SummonInformation summon3 = new SummonInformation(10, TravelDirection.Down);
            SummonInformation request2 = new SummonInformation(1, TravelDirection.None, summon2);
            SummonInformation request3 = new SummonInformation(8, TravelDirection.None, summon3);
            IList<SummonInformation> requests = new List<SummonInformation>()
            {
                summon1,
                request1,
                summon2,
                summon3,
                request2,
                request3
            };

            var executionPlan = lift.ProcessRequests(requests);

            var planResult = executionPlan.GetFloorVisitationPlan();
            Assert.Equal(6, planResult.Count());
        }
        [Fact]
        public void ExecutionPlan_HasExpectedAscUpToMaxFloorThenDesc_WhenSummonedFrom3FloorsTo3DifferentsFloors()
        {
            FloorConfiguration floorConfig = new FloorConfiguration(2, 0, 15);
            IExecutionPlan plan = new ExecutionPlan();
            ILift lift = new Lift(floorConfig, plan);
            SummonInformation summon1 = new SummonInformation(0, TravelDirection.Up);
            SummonInformation request1 = new SummonInformation(5, TravelDirection.None, summon1);
            SummonInformation summon2 = new SummonInformation(4, TravelDirection.Down);
            SummonInformation summon3 = new SummonInformation(10, TravelDirection.Down);
            SummonInformation request2 = new SummonInformation(0, TravelDirection.None, summon2);
            SummonInformation request3 = new SummonInformation(8, TravelDirection.None, summon3);
            IList<SummonInformation> requests = new List<SummonInformation>()
            {
                summon1,
                request1,
                summon2,
                summon3,
                request2,
                request3
            };

            var executionPlan = lift.ProcessRequests(requests);

            var planResult = executionPlan.GetFloorVisitationPlan();
            Assert.Equal(summon1.SummonFloor, planResult.ElementAt(0));
            Assert.Equal(request1.SummonFloor, planResult.ElementAt(1));
            Assert.Equal(summon3.SummonFloor, planResult.ElementAt(2));
            Assert.Equal(request3.SummonFloor, planResult.ElementAt(3));
            Assert.Equal(summon2.SummonFloor, planResult.ElementAt(4));
            Assert.Equal(request2.SummonFloor, planResult.ElementAt(5));
        }
        
        //Parked:6 - Passenger 1 summons lift to go up from Ground.They choose L9.Passenger 2 summons lift to go down from L7.Passenger 3 summons lift to go down from L10.Passengers 2 goes to L4 and 3 choose to travel to L8.
        [Fact]
        public void Lift_CreateExecutionPlanWith6Values_WhenSummonedFrom3FloorsTo3DifferentsFloorsAnd2OfThemCrossParkedValue()
        {
            FloorConfiguration floorConfig = new FloorConfiguration(5, 0, 15);
            IExecutionPlan plan = new ExecutionPlan();
            ILift lift = new Lift(floorConfig, plan);
            SummonInformation summon1 = new SummonInformation(0, TravelDirection.Up);
            SummonInformation request1 = new SummonInformation(5, TravelDirection.None, summon1);
            SummonInformation summon2 = new SummonInformation(7, TravelDirection.Down);
            SummonInformation summon3 = new SummonInformation(10, TravelDirection.Down);
            SummonInformation request2 = new SummonInformation(4, TravelDirection.None, summon2);
            SummonInformation request3 = new SummonInformation(8, TravelDirection.None, summon3);
            IList<SummonInformation> requests = new List<SummonInformation>()
            {
                summon1,
                request1,
                summon2,
                summon3,
                request2,
                request3
            };

            var executionPlan = lift.ProcessRequests(requests);

            var planResult = executionPlan.GetFloorVisitationPlan();
            Assert.Equal(6, planResult.Count());
        }
        [Fact]
        public void ExecutionPlan_HasExpectedAscUpToMaxFloorThenDesc_WhenSummonedFrom3FloorsTo3DifferentsFloorsAnd2OfThemCrossParkedValue()
        {
            FloorConfiguration floorConfig = new FloorConfiguration(2, 0, 15);
            IExecutionPlan plan = new ExecutionPlan();
            ILift lift = new Lift(floorConfig, plan);
            SummonInformation summon1 = new SummonInformation(0, TravelDirection.Up);
            SummonInformation request1 = new SummonInformation(5, TravelDirection.None, summon1);
            SummonInformation summon2 = new SummonInformation(7, TravelDirection.Down);
            SummonInformation summon3 = new SummonInformation(10, TravelDirection.Down);
            SummonInformation request2 = new SummonInformation(4, TravelDirection.None, summon2);
            SummonInformation request3 = new SummonInformation(8, TravelDirection.None, summon3);
            IList<SummonInformation> requests = new List<SummonInformation>()
            {
                summon1,
                request1,
                summon2,
                summon3,
                request2,
                request3
            };

            var executionPlan = lift.ProcessRequests(requests);

            var planResult = executionPlan.GetFloorVisitationPlan();
            Assert.Equal(summon1.SummonFloor, planResult.ElementAt(0));
            Assert.Equal(request1.SummonFloor, planResult.ElementAt(1));
            Assert.Equal(summon3.SummonFloor, planResult.ElementAt(2));
            Assert.Equal(request3.SummonFloor, planResult.ElementAt(3));
            Assert.Equal(summon2.SummonFloor, planResult.ElementAt(4));
            Assert.Equal(request2.SummonFloor, planResult.ElementAt(5));

        }
    }
}
