using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NoOpArmy.WiseFeline.Sample
{
    public class AgentEnemy : AgentController
    {
        public override void Rest(float health)
        {
            Health += health;
            _agentHUD.HealthUI.UpdateAmount(Health);
        }
    }
}
