using System;
using System.Collections.Generic;
using LiftTravelControl.Interfaces;
using LiftTravelControl.Pocos;
using System.Linq;

namespace LiftTravelControl
{
    public class Lift : ILift
    {
        public int CurrentFloor => _floorConfiguration.CurrentFloor;
        public LiftState CurrentState => _state;

        private FloorConfiguration _floorConfiguration;
        private LiftState _state = LiftState.Parked;

        private IExecutionPlan _executionPlan;

        public Lift(FloorConfiguration floorConfiguration, IExecutionPlan executionPlan)
        {
            _floorConfiguration = floorConfiguration;
            _executionPlan = executionPlan;
        }

        IExecutionPlan ILift.ProcessRequests(IList<SummonInformation> requests)
        {
            IsFirstRequestValid(requests);

            _executionPlan.Clear();

            if (_state == LiftState.Parked
                && IsFirstRequestForCurrentFloor(requests.First()))
            {
                requests.RemoveAt(0);
            }

            foreach (var summon in requests)
            {
                _executionPlan.Add(summon);
            }

            return _executionPlan;
        }

        private bool IsFirstRequestForCurrentFloor(SummonInformation summonInformation)
        {
            return CurrentFloor == summonInformation.SummonFloor;
        }

        private void IsFirstRequestValid(IEnumerable<SummonInformation> requests)
        {
            if (!requests.Any())
            {
                throw new ArgumentException("Must have request");
            } else if (!IsExistingExecutionPlan()
                    && !IsFirstRequestSummonFromOutSide(requests))
            {
                throw new ArgumentException("Must be summon request");
            }
        }

        private static bool IsFirstRequestSummonFromOutSide(IEnumerable<SummonInformation> requests)
        {
            return requests?.FirstOrDefault()?.Direction != TravelDirection.None;
        }

        private bool IsExistingExecutionPlan()
        {
            return _executionPlan?.GetPlan()?.Any() ?? false;
        }
    }
}
