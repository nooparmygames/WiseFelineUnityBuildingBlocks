using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NoOpArmy.WiseFeline.Sample
{
    public class Home : MonoBehaviour
    {
        [SerializeField]
        private float _restRate = 1f;

        private List<AgentController> _inHomeAgents;
        private void Awake()
        {
            _inHomeAgents = new List<AgentController>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out AgentController agentController))
            {
                if (!_inHomeAgents.Contains(agentController))
                    _inHomeAgents.Add(agentController);
                if (agentController is AgentEnemy)
                    agentController.HaveStack = false;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out AgentController agentController))
            {
                if (_inHomeAgents.Contains(agentController))
                    _inHomeAgents.Remove(agentController);
            }
        }

        private void Update()
        {
            foreach (var agent in _inHomeAgents)
            {
                agent.Rest(Time.deltaTime * _restRate);
            }
        }
    }
}
