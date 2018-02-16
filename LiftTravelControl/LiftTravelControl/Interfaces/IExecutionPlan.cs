using System.Collections.Generic;
using LiftTravelControl.Pocos;

namespace LiftTravelControl.Interfaces
{
    public interface IExecutionPlan
    {
        IEnumerable<int> GetFloorVisitationPlan();
        IEnumerable<SummonInformation> GetPlan();
        void Clear();
        void Add(SummonInformation summonInformation);
    }
}