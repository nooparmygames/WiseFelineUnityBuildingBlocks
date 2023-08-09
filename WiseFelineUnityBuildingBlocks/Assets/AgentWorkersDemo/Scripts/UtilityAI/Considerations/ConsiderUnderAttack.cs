using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NoOpArmy.WiseFeline.Sample
{
    public class ConsiderUnderAttack : ConsiderationBase
    {
        protected override float GetValue(Component target)
        {
            return target.GetComponent<AgentController>().IsUnderAttack ? 1f : 0f;
        }
    }
}
