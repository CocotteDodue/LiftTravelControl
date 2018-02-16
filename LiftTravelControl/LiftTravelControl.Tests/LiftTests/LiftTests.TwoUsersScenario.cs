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
        [Fact]
        public void Lift_CreateExecutionPlanWith3Values_WhenSummonedFrom2FloorsToGoDownAndParkedHigherThanBothAndIdenticalRequestedFloor()
        {
            FloorConfiguration floorConfig = new FloorConfiguration(8, 0, 15);
            IExecutionPlan plan = new ExecutionPlan();
            ILift lift = new Lift(floorConfig, plan);
            SummonInformation summon1 = new SummonInformation(6, TravelDirection.Down);
            SummonInformation request1 = new SummonInformation(1, TravelDirection.None);
            SummonInformation summon2 = new SummonInformation(4, TravelDirection.Down);
            SummonInformation request2 = new SummonInformation(1, TravelDirection.None);
            IList<SummonInformation> requests = new List<SummonInformation>()
            {
                summon1,
                request1,
                summon2,
                request2
            };

            var executionPlan = lift.ProcessRequests(requests);

            var planResult = executionPlan.GetFloorVisitationPlan();
            Assert.Equal(3, planResult.Count());
        }

        [Fact]
        public void ExecutionPlan_HasSummonAndDesitnationInCallOrder_WhenSummonedFrom2FloorsToGoDownAndParkedHigherThanBothAndRequestImmediatlyFollowSummon()
        {
            FloorConfiguration floorConfig = new FloorConfiguration(8, 0, 15);
            IExecutionPlan plan = new ExecutionPlan();
            ILift lift = new Lift(floorConfig, plan);
            SummonInformation summon1 = new SummonInformation(6, TravelDirection.Down);
            SummonInformation request1 = new SummonInformation(1, TravelDirection.None);
            SummonInformation summon2 = new SummonInformation(4, TravelDirection.Down);
            SummonInformation request2 = new SummonInformation(1, TravelDirection.None);
            IList<SummonInformation> requests = new List<SummonInformation>()
            {
                summon1,
                request1,
                summon2,
                request2
            };

            var executionPlan = lift.ProcessRequests(requests);

            var planResult = executionPlan.GetFloorVisitationPlan();
            Assert.Equal(summon1.SummonFloor, planResult.ElementAt(0));
            Assert.Equal(summon2.SummonFloor, planResult.ElementAt(1));
            Assert.Equal(request1.SummonFloor, planResult.ElementAt(2));
        }
        
        [Fact]
        public void ExecutionPlan_HasSummonAndDesitnationInCallOrder_WhenSummonedFrom2FloorsToGoDownAndParkedHigherThanBothAndAllSummonsAreFirst()
        {
            FloorConfiguration floorConfig = new FloorConfiguration(8, 0, 15);
            IExecutionPlan plan = new ExecutionPlan();
            ILift lift = new Lift(floorConfig, plan);
            SummonInformation summon1 = new SummonInformation(6, TravelDirection.Down);
            SummonInformation request1 = new SummonInformation(1, TravelDirection.None);
            SummonInformation summon2 = new SummonInformation(4, TravelDirection.Down);
            SummonInformation request2 = new SummonInformation(1, TravelDirection.None);
            IList<SummonInformation> requests = new List<SummonInformation>()
            {
                summon1,
                summon2,
                request1,
                request2
            };

            var executionPlan = lift.ProcessRequests(requests);

            var planResult = executionPlan.GetFloorVisitationPlan();
            Assert.Equal(summon1.SummonFloor, planResult.ElementAt(0));
            Assert.Equal(summon2.SummonFloor, planResult.ElementAt(1));
            Assert.Equal(request1.SummonFloor, planResult.ElementAt(2));
        }
    }
}
