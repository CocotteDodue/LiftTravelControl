using LiftTravelControl.Interfaces;
using LiftTravelControl.Enum;
using System;
using System.Collections.Generic;
using Xunit;

namespace LiftTravelControl.Tests.LiftTests
{
    public partial class LiftTests
    {
        [Fact]
        public void Lift_MustThrowException_WhenFirstRequestNotSummonWithDirectionAndNoExecutionPlanExist()
        {
            FloorConfiguration floorConfig = new FloorConfiguration(3, 0, 15);
            ILift lift = new Lift(floorConfig, null);
            IList<SummonInformation> requests = new List<SummonInformation>()
            {
                new SummonInformation(floorConfig.CurrentFloor + 1, TravelDirection.None)
            };

            Assert.Throws<ArgumentException>(() => lift.ProcessRequests(requests));
        }

        [Fact]
        public void Lift_MustThrowException_WhenFirstRequestNotSummonWithDirectionAndNoExecutionPlanComputed()
        {
            FloorConfiguration floorConfig = new FloorConfiguration(3, 0, 15);
            IExecutionPlan plan = new ExecutionPlan();
            ILift lift = new Lift(floorConfig, plan);
            IList<SummonInformation> requests = new List<SummonInformation>()
            {
                new SummonInformation(floorConfig.CurrentFloor + 1, TravelDirection.None)
            };

            Assert.Throws<ArgumentException>(() => lift.ProcessRequests(requests));
        }

        [Fact]
        public void Lift_MustThrowException_WhenNoRequestIsMade()
        {
            FloorConfiguration floorConfig = new FloorConfiguration(3, 0, 15);
            IExecutionPlan plan = new ExecutionPlan();
            ILift lift = new Lift(floorConfig, plan);
            IList<SummonInformation> requests = new List<SummonInformation>();

            Assert.Throws<ArgumentException>(() => lift.ProcessRequests(requests));
        }
    }
}
