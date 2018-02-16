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
        #region same destination floor
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
    
        [Fact]
        public void ExecutionPlan_HasSummonAndDesitnationDescOrder_WhenSummonedFrom2FloorsToGoDownAndParkedHigherThanBothAndRequestImmediatlyFollowSummonAndFirstRequestIsFromLowerFloor()
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
                summon2,
                request2,
                summon1,
                request1
            };

            var executionPlan = lift.ProcessRequests(requests);

            var planResult = executionPlan.GetFloorVisitationPlan();
            Assert.Equal(summon1.SummonFloor, planResult.ElementAt(0));
            Assert.Equal(summon2.SummonFloor, planResult.ElementAt(1));
            Assert.Equal(request1.SummonFloor, planResult.ElementAt(2));
        }

        [Fact]
        public void ExecutionPlan_HasSummonAndDesitnationDescOrder_WhenSummonedFrom2FloorsToGoDownAndParkedHigherThanBothAndAllSummonsAreFirstAndFirstRequestIsFromLowerFloor()
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
                summon2,
                summon1,
                request1,
                request2
            };

            var executionPlan = lift.ProcessRequests(requests);

            var planResult = executionPlan.GetFloorVisitationPlan();
            Assert.Equal(summon1.SummonFloor, planResult.ElementAt(0));
            Assert.Equal(summon2.SummonFloor, planResult.ElementAt(1));
            Assert.Equal(request1.SummonFloor, planResult.ElementAt(2));
        }

        [Fact]
        public void ExecutionPlan_HasSummonAndDesitnationDescOrder_WhenSummonedFrom2FloorsToGoDownAndParkedLowerThanBothAndRequestImmediatlyFollowSummon()
        {
            FloorConfiguration floorConfig = new FloorConfiguration(3, 0, 15);
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
        public void ExecutionPlan_HasSummonAndDesitnationDescOrder_WhenSummonedFrom2FloorsToGoDownAndParkedLowerThanBothAndAllSummonsAreFirst()
        {
            FloorConfiguration floorConfig = new FloorConfiguration(3, 0, 15);
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

        [Fact]
        public void ExecutionPlan_HasSummonAndDesitnationDescOrder_WhenSummonedFrom2FloorsToGoDownAndParkedLowerThanBothAndRequestImmediatlyFollowSummonAnd1RequestIsExtremumFloor()
        {
            FloorConfiguration floorConfig = new FloorConfiguration(3, 0, 15);
            IExecutionPlan plan = new ExecutionPlan();
            ILift lift = new Lift(floorConfig, plan);
            SummonInformation summon1 = new SummonInformation(15, TravelDirection.Down);
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
        public void ExecutionPlan_HasSummonAndDesitnationDescOrder_WhenSummonedFrom2FloorsToGoDownAndParkedLowerThanBothAndAllSummonsAreFirstAnd1RequestIsExtremumFloor()
        {
            FloorConfiguration floorConfig = new FloorConfiguration(3, 0, 15);
            IExecutionPlan plan = new ExecutionPlan();
            ILift lift = new Lift(floorConfig, plan);
            SummonInformation summon1 = new SummonInformation(6, TravelDirection.Down);
            SummonInformation request1 = new SummonInformation(1, TravelDirection.None);
            SummonInformation summon2 = new SummonInformation(15, TravelDirection.Down);
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
            Assert.Equal(summon2.SummonFloor, planResult.ElementAt(0));
            Assert.Equal(summon1.SummonFloor, planResult.ElementAt(1));
            Assert.Equal(request1.SummonFloor, planResult.ElementAt(2));
        }
        #endregion

        #region different destination floors
        [Fact]
        public void Lift_CreateExecutionPlanWith3Values_WhenSummonedFrom2FloorsHigherThanParkedToGoDownAndDifferentRequestedFloors()
        {
            FloorConfiguration floorConfig = new FloorConfiguration(5, 0, 15);
            IExecutionPlan plan = new ExecutionPlan();
            ILift lift = new Lift(floorConfig, plan);
            SummonInformation summon1 = new SummonInformation(6, TravelDirection.Down);
            SummonInformation request1 = new SummonInformation(1, TravelDirection.None);
            SummonInformation summon2 = new SummonInformation(9, TravelDirection.Down);
            SummonInformation request2 = new SummonInformation(3, TravelDirection.None);
            IList<SummonInformation> requests = new List<SummonInformation>()
            {
                summon1,
                request1,
                summon2,
                request2
            };

            var executionPlan = lift.ProcessRequests(requests);

            var planResult = executionPlan.GetFloorVisitationPlan();
            Assert.Equal(4, planResult.Count());
        }
        [Fact]
        public void ExecutionPlan_HasSummonAndDesitnationDescOrder_WhenSummonedFrom2FloorsHigherThanParkedToGoDownAndDifferentRequestedFloors()
        {
            FloorConfiguration floorConfig = new FloorConfiguration(5, 0, 15);
            IExecutionPlan plan = new ExecutionPlan();
            ILift lift = new Lift(floorConfig, plan);
            SummonInformation summon1 = new SummonInformation(6, TravelDirection.Down);
            SummonInformation request1 = new SummonInformation(1, TravelDirection.None);
            SummonInformation summon2 = new SummonInformation(9, TravelDirection.Down);
            SummonInformation request2 = new SummonInformation(3, TravelDirection.None);
            IList<SummonInformation> requests = new List<SummonInformation>()
            {
                summon1,
                request1,
                summon2,
                request2
            };

            var executionPlan = lift.ProcessRequests(requests);

            var planResult = executionPlan.GetFloorVisitationPlan();
            Assert.Equal(summon2.SummonFloor, planResult.ElementAt(0));
            Assert.Equal(summon1.SummonFloor, planResult.ElementAt(1));
            Assert.Equal(request2.SummonFloor, planResult.ElementAt(2));
            Assert.Equal(request1.SummonFloor, planResult.ElementAt(3));
        }
        [Fact]
        public void ExecutionPlan_HasSummonAndDesitnationAscOrder_WhenSummonedFrom2DifferentFloorsHigherThanParkedToUpAndDifferentRequestedFloorsAndUser2RequestLowerFloorThanUser1Summoning()
        {
            FloorConfiguration floorConfig = new FloorConfiguration(1, 0, 15);
            IExecutionPlan plan = new ExecutionPlan();
            ILift lift = new Lift(floorConfig, plan);
            SummonInformation summon1 = new SummonInformation(6, TravelDirection.Up);
            SummonInformation request1 = new SummonInformation(9, TravelDirection.None);
            SummonInformation summon2 = new SummonInformation(4, TravelDirection.Up);
            SummonInformation request2 = new SummonInformation(5, TravelDirection.None);
            IList<SummonInformation> requests = new List<SummonInformation>()
            {
                summon1,
                request1,
                summon2,
                request2
            };

            var executionPlan = lift.ProcessRequests(requests);

            var planResult = executionPlan.GetFloorVisitationPlan();
            Assert.Equal(summon2.SummonFloor, planResult.ElementAt(0));
            Assert.Equal(request2.SummonFloor, planResult.ElementAt(1));
            Assert.Equal(summon1.SummonFloor, planResult.ElementAt(2));
            Assert.Equal(request1.SummonFloor, planResult.ElementAt(3));
        }
        [Fact]
        public void ExecutionPlan_HasSummonAndDesitnationAscOrder_WhenSummonedFrom2DifferentFloorsHigherThanParkedToUpAndDifferentRequestedFloorsAndUser2RequestLowerFloorThanUser1SummoningAndParkedFloorInBetween()
        {
            FloorConfiguration floorConfig = new FloorConfiguration(5, 0, 15);
            IExecutionPlan plan = new ExecutionPlan();
            ILift lift = new Lift(floorConfig, plan);
            SummonInformation summon1 = new SummonInformation(6, TravelDirection.Up);
            SummonInformation request1 = new SummonInformation(9, TravelDirection.None);
            SummonInformation summon2 = new SummonInformation(0, TravelDirection.Up);
            SummonInformation request2 = new SummonInformation(3, TravelDirection.None);
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
            Assert.Equal(request1.SummonFloor, planResult.ElementAt(1));
            Assert.Equal(summon2.SummonFloor, planResult.ElementAt(2));
            Assert.Equal(request2.SummonFloor, planResult.ElementAt(3));
        }
        [Fact]
        public void ExecutionPlan_HasSummonAndDesitnationAscOrder_WhenSummonedFrom2DifferentFloorsLowerThanParkedToUpAndDifferentRequestedFloorsAndUser2RequestLowerFloorThanUser1()
        {
            FloorConfiguration floorConfig = new FloorConfiguration(8, 0, 15);
            IExecutionPlan plan = new ExecutionPlan();
            ILift lift = new Lift(floorConfig, plan);
            SummonInformation summon1 = new SummonInformation(6, TravelDirection.Up);
            SummonInformation request1 = new SummonInformation(13, TravelDirection.None);
            SummonInformation summon2 = new SummonInformation(4, TravelDirection.Up);
            SummonInformation request2 = new SummonInformation(12, TravelDirection.None);
            IList<SummonInformation> requests = new List<SummonInformation>()
            {
                summon1,
                request1,
                summon2,
                request2
            };

            var executionPlan = lift.ProcessRequests(requests);

            var planResult = executionPlan.GetFloorVisitationPlan();
            Assert.Equal(summon2.SummonFloor, planResult.ElementAt(0));
            Assert.Equal(summon1.SummonFloor, planResult.ElementAt(1));
            Assert.Equal(request2.SummonFloor, planResult.ElementAt(2));
            Assert.Equal(request1.SummonFloor, planResult.ElementAt(3));
        }

        #endregion
    }
}
