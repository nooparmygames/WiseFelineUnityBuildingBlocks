using UnityEngine;

namespace NoOpArmy.WiseFeline.Sample
{
    public class Sleep : ActionBase
    {
        private AgentController _agentController;

        protected override void OnInitialized()
        {
            _agentController = Brain.GetComponent<AgentController>();
        }

        protected override void OnStart()
        {
            _agentController.Movement.GoToHome(null);
        }

        protected override void UpdateTargets()
        {
            
        }
    }
}
