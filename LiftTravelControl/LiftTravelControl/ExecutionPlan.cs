using System.Collections.Generic;
using LiftTravelControl.Interfaces;
using LiftTravelControl.Pocos;

namespace LiftTravelControl
{
    public class ExecutionPlan : IExecutionPlan
    {
        private IList<int> _floorList;

        public ExecutionPlan(IList<int> floorList)
        {
            _floorList = floorList;
        }
        public ExecutionPlan() 
            : this(new List<int>())
        { }

        public void Clear()
        {
            _floorList.Clear();
        }

        public IEnumerable<int> GetPlan()
        {
            return _floorList;
        }

        public void Add(SummonInformation summonInformation)
        {
            _floorList.Add(summonInformation.SummonFloor);
        }
    }
}
