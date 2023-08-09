using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NoOpArmy.WiseFeline.Sample
{
    public class ConsiderStack : ConsiderationBase
    {
        protected override float GetValue(Component target)
        {
            return target.GetComponent<AgentController>().HaveStack ? 1 : 0;
        }
    }
}
