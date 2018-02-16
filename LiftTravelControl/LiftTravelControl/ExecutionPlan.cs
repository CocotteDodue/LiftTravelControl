using System.Collections.Generic;
using LiftTravelControl.Interfaces;
using LiftTravelControl.Pocos;
using System.Linq;

namespace LiftTravelControl
{
    public class ExecutionPlan : IExecutionPlan
    {
        private IList<SummonInformation> _visitationPlan;

        public ExecutionPlan(IList<SummonInformation> visitationPlan)
        {
            _visitationPlan = visitationPlan;
        }
        public ExecutionPlan() 
            : this(new List<SummonInformation>())
        { }

        public void Clear()
        {
            _visitationPlan.Clear();
        }

        public IEnumerable<int> GetFloorVisitationPlan()
        {
            return _visitationPlan.Select(info => info.SummonFloor).ToList();
        }

        public void Add(SummonInformation summonInformation)
        {
            if (!_visitationPlan.Contains(summonInformation))
            {
                _visitationPlan.Add(summonInformation);
            }
        }

        public IEnumerable<SummonInformation> GetPlan()
        {
            throw new System.NotImplementedException();
        }
    }
}
