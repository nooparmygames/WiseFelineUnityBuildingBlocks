using UnityEngine;
using NoOpArmy.WiseFeline;

namespace NoOpArmy.WiseFeline.Sample
{
    public class ConsiderHealth : ConsiderationBase
    {
        protected override float GetValue(Component target)
        {
            return target.GetComponent<AgentController>().Health;
        }
    }
}
