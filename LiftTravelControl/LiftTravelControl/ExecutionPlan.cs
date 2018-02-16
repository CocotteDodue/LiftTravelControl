using LiftTravelControl.Interfaces;
using System.Collections.Generic;
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
            return _visitationPlan;
        }

        public bool CanAddToExecutionPlan(SummonInformation summon)
        {
            if (summon.IsInsideCall())
            {
                return IsTriggeringSummonInExecutionPlan(summon.TriggeringSummon);
            }

            return true;
        }
        public override string ToString()
        {
            return string.Join(',', GetFloorVisitationPlan());
        }

        private bool IsTriggeringSummonInExecutionPlan(SummonInformation triggeringSummon)
        {
            return _visitationPlan.Contains(triggeringSummon);
        }
    }
}
