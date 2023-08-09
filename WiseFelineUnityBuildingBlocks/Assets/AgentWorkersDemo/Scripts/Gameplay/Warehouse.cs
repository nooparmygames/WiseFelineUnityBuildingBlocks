using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NoOpArmy.WiseFeline.Sample
{
    public class Warehouse : MonoBehaviour
    {
        [SerializeField]
        private float _storeEnergyCost = 10f;

        public int Storage { get { return _storage; } }

        private int _storage;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out AgentWorker agentWorker))
            {
                if (agentWorker.HaveStack == true)
                {
                    agentWorker.HaveStack = false;
                    agentWorker.Energy -= _storeEnergyCost;
                    _storage += 6;
                    GameManager.Instance.AddToTotalWood(6);
                }
            }
            else if (other.TryGetComponent(out AgentEnemy enemyAgent))
            {
                enemyAgent.HaveStack = true;
                GameManager.Instance.AddToTotalWood(-6);
            }
        }
    }
}
