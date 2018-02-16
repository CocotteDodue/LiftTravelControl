using System.Collections.Generic;
using LiftTravelControl.Pocos;

namespace LiftTravelControl.Interfaces
{
    public interface IExecutionPlan
    {
        IEnumerable<int> GetPlan();
        void Clear();
        void Add(SummonInformation summonInformation);
    }
}