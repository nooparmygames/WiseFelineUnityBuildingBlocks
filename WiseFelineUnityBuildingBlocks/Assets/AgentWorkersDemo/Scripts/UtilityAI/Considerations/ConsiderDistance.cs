using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NoOpArmy.WiseFeline.Sample
{
    public class ConsiderDistance : ConsiderationBase
    {
        private AgentController _agentController;

        protected override void OnInitialized()
        {
            _agentController = Brain.GetComponent<AgentController>();
        }

        protected override float GetValue(Component target)
        {
            float distance = (target.transform.position - _agentController.transform.position).magnitude;
            return distance;
        }
    }
}
