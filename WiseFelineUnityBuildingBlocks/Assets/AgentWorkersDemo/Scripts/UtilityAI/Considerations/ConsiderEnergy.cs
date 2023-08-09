using UnityEngine;

namespace NoOpArmy.WiseFeline.Sample
{
    public class ConsiderEnergy : ConsiderationBase
    {
        protected override float GetValue(Component target)
        {
            return target.GetComponent<AgentWorker>().Energy;
        }
    }
}
