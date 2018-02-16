using LiftTravelControl.Enum;
using LiftTravelControl.Extensions;
using LiftTravelControl.Interfaces;
using System;
using System.Collections.Generic;
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
                _executionPlan.Add(requests.First());
                requests.RemoveAt(0);
            }

            TravelDirection direction = GetInitialDirectionOfTravel(requests.First());

            var boundaries = _floorConfiguration.GetBoundariesForDirection(direction);
            ProcessSummonsRequestSegment(requests, direction, boundaries, true);

            if (NeedToRunSameSegmentInOppositeDirection(requests.First(), direction))
            {
                direction = InverseDirection(direction);
                ProcessSummonsRequestSegment(requests, direction, boundaries, false);
            }
            
            SwitchBoundaries(ref boundaries);
            ProcessSummonsRequestSegment(requests, direction, boundaries, true);

            direction = InverseDirection(direction);
            boundaries = _floorConfiguration.GetFullRangeBoundariesForDirection(direction);
            ProcessSummonsRequestSegment(requests, direction, boundaries, true);

            return _executionPlan;
        }

        private void ProcessSummonsRequestSegment(IList<SummonInformation> requests, TravelDirection direction, Boundaries boundaries, bool handleExtremum)
        {
            IList<SummonInformation> selectedSummons = GetAllSummonsForDirectionOfTravelInBoundaries(requests, direction, boundaries).ToList();

            if (handleExtremum)
            {
                HandleSummonForBoundaries(requests, direction, boundaries, selectedSummons);
            }

            foreach (var summon in selectedSummons)
            {
                if (_executionPlan.CanAddToExecutionPlan(summon))
                {
                    _executionPlan.Add(summon);
                }
            }
        }

        private void HandleSummonForBoundaries(IList<SummonInformation> requests, TravelDirection direction, Boundaries boundaries, IList<SummonInformation> selectedSummons)
        {
            foreach (var summon in requests)
            {
                if (boundaries.IsExtremum(direction, summon.SummonFloor))
                {
                    selectedSummons.Add(summon);
                }
            }
        }

        private void SwitchBoundaries(ref Boundaries boundaries)
        {
            TravelDirection directionForCurrentBoundaries = GetBoundariesDirection(boundaries);

            boundaries = _floorConfiguration.GetBoundariesForDirection(directionForCurrentBoundaries == TravelDirection.Up
                            ? TravelDirection.Down
                            : TravelDirection.Up);
        }

        private TravelDirection GetBoundariesDirection(Tuple<int, int> boundaries)
        {
            return (_floorConfiguration.GetBoundariesForDirection(TravelDirection.Up).Equals(boundaries))
                        ? TravelDirection.Up
                        : TravelDirection.Down;
        }

        private bool NeedToRunSameSegmentInOppositeDirection(SummonInformation firstSummon, TravelDirection direction)
        {
            return firstSummon.Direction != direction;
        }

        private TravelDirection InverseDirection(TravelDirection direction)
        {
            return direction == TravelDirection.None
                ? TravelDirection.None
                : direction == TravelDirection.Up
                    ? TravelDirection.Down
                    : TravelDirection.Up;
        }

        private IList<SummonInformation> GetAllSummonsForDirectionOfTravelInBoundaries(IList<SummonInformation> requests, TravelDirection direction, Boundaries boundaries)
        {
            var selectedSummons = requests.Where(summon =>
            {
                return !boundaries.IsExtremum(direction, summon.SummonFloor)
                       && IsSummonRequestInBoundariesAndMatchingDirection(summon, direction, boundaries);
            }).ToList();

            return direction == TravelDirection.Up
                        ? selectedSummons.OrderBy(summon => summon.SummonFloor).ToList()
                        : selectedSummons.OrderByDescending(summon => summon.SummonFloor).ToList();
        }

        private bool IsSummonRequestInBoundariesAndMatchingDirection(SummonInformation summon, TravelDirection direction, Tuple<int, int> boundaries)
        {
            return (summon.Direction == direction || summon.Direction == TravelDirection.None)
                    && summon.SummonFloor.Between(boundaries.Item1, boundaries.Item2);
        }

        private TravelDirection GetInitialDirectionOfTravel(SummonInformation firstSummon)
        {
            return firstSummon.SummonFloor == CurrentFloor
                ? firstSummon.Direction
                : DeduceTravelDirection(firstSummon);
        }

        private TravelDirection DeduceTravelDirection(SummonInformation summon)
        {
            return (CurrentFloor < summon.SummonFloor)
                ? TravelDirection.Up
                : TravelDirection.Down;
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
            return _executionPlan?.GetFloorVisitationPlan()?.Any() ?? false;
        }
    }
}
