using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NoOpArmy.WiseFeline.Sample
{
    public class VillageBoundry : MonoBehaviour
    {
        private List<AgentEnemy> _agentEnemies;
        private List<AgentEnemy> _enemiesToRemove;
        private bool _isUnderAttack;

        private void Awake()
        {
            _agentEnemies = new List<AgentEnemy>();
            _enemiesToRemove = new List<AgentEnemy>();
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.TryGetComponent(out AgentEnemy agentEnemy))
            {
                if (!_agentEnemies.Contains(agentEnemy))
                {
                    _agentEnemies.Add(agentEnemy);
                    if (!_isUnderAttack)
                    {
                        _isUnderAttack = true;
                        GameManager.Instance.IsVillageUnderAttack = true;
                    }
                }
            }
        }

        private void Update()
        {
            if (_agentEnemies.Count == 0)
                return;

            _enemiesToRemove.Clear();
            foreach (var agent in _agentEnemies)
            {
                if (agent == null)
                {
                    if (_agentEnemies.Contains(agent))
                    {
                        _enemiesToRemove.Add(agent);
                        
                    }
                }
            }

            _agentEnemies.RemoveAll(e => _enemiesToRemove.Contains(e));
            if (_agentEnemies.Count == 0)
            {
                if (_isUnderAttack)
                {
                    _isUnderAttack = false;
                    GameManager.Instance.IsVillageUnderAttack = false;
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out AgentEnemy agentEnemy))
            {
                if (_agentEnemies.Contains(agentEnemy))
                {
                    _agentEnemies.Remove(agentEnemy);
                    if (_agentEnemies.Count == 0)
                    {
                        if (_isUnderAttack)
                        {
                            _isUnderAttack = false;
                            GameManager.Instance.IsVillageUnderAttack = false;
                        }
                    }
                }
            }
        }
    }
}
