using System.Collections.Generic;
using LiftTravelControl.Enum;

namespace LiftTravelControl.Interfaces
{
    public interface IExecutionPlan
    {
        IEnumerable<int> GetFloorVisitationPlan();
        IEnumerable<SummonInformation> GetPlan();
        void Clear();
        void Add(SummonInformation summonInformation);
        bool CanAddToExecutionPlan(SummonInformation summon);
    }
}