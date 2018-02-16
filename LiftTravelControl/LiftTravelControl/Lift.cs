using System;
using System.Collections.Generic;
using LiftTravelControl.Interfaces;
using LiftTravelControl.Enum;
using System.Linq;
using LiftTravelControl.Extensions;

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

            // first request of all gives the directioin of travel
            // find the highest(lowest floor to reach in this direction)
            // add all the floor to reach in the direction
            // add requested floor from inside according to the travel direction of the lift when the floor is reached
            // do not add duplicate
            // cannot travel toa destination before being requested for? -> request order matter?
            // can travel twice to a level if requested twice with up and down for instance?

            // first summon: direction of travel of the elevator until reach first summon floor
            // if 

            TravelDirection direction = GetInitialDirectionOfTravel(requests.First());
            // get all the summon above (for up) / bellow (down)
            var boundaries = _floorConfiguration.GetBoundariesForDirection(direction);
            IList<SummonInformation> directionOfTravelSummons = GetAllSummonsForDirectionOfTravelInBoundaries(requests, direction, boundaries).ToList();
            // handle extremum
            HandleSummonForBoundaries(requests, direction, boundaries, directionOfTravelSummons);

            foreach (var summon in directionOfTravelSummons)
            {
                if (_executionPlan.CanAddToExecutionPlan(summon))
                {
                    _executionPlan.Add(summon);
                }
            }


            if (NeedToRunSameSegmentInOppositeDirection(requests.First(), direction))
            {
                direction = InverseDirection(direction);
                IEnumerable<SummonInformation> InverseDirectionOfTravelSummons = GetAllSummonsForDirectionOfTravelInBoundaries(requests, direction, boundaries).ToList();

                foreach (var summon in InverseDirectionOfTravelSummons)
                {
                    if (_executionPlan.CanAddToExecutionPlan(summon))
                    {
                        _executionPlan.Add(summon);
                    }
                }
            }

            // handle current ?

            //switch boudaries
            SwitchBoundaries(ref boundaries);
            
            directionOfTravelSummons = GetAllSummonsForDirectionOfTravelInBoundaries(requests, direction, boundaries).ToList();

            foreach (var summon in directionOfTravelSummons)
            {
                if (_executionPlan.CanAddToExecutionPlan(summon))
                {
                    _executionPlan.Add(summon);
                }
            }

            // handle extremum
            
            direction = InverseDirection(direction);
            IEnumerable<SummonInformation> remaining = GetAllSummonsForDirectionOfTravelInBoundaries(requests, direction, boundaries).ToList();

            foreach (var summon in remaining)
            {
                if (_executionPlan.CanAddToExecutionPlan(summon))
                {
                    _executionPlan.Add(summon);
                }
            }

            return _executionPlan;
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
            return (_floorConfiguration.GetBoundariesForDirection(TravelDirection.Up) == boundaries)
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

        //private bool IsExtremumBoundary(SummonInformation summon, TravelDirection direction, Tuple<int, int> boundaries)
        //{
        //    int extremumBoundary = GetExtremum(direction, boundaries);

        //    return summon.SummonFloor == extremumBoundary;
        //}

        //private static int GetExtremum(TravelDirection direction, Tuple<int, int> boundaries)
        //{
        //    return direction == TravelDirection.Up
        //                    ? boundaries.Item2
        //                    : boundaries.Item1;
        //}

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
