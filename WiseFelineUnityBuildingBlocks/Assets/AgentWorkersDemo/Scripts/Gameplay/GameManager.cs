using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NoOpArmy.WiseFeline.Sample
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;

        public int Wood { get; private set; }
        public int WorkersCount { get; private set; }
        public bool IsVillageUnderAttack { get { return _isVillageUnderAttack; } 
            set
            {
                if (_isVillageUnderAttack != value)
                {
                    if (value)
                        Defend();
                    else
                        Work();
                }
                _isVillageUnderAttack = value;
            }
        }

        private List<AgentWorker> _allAgents;
        private bool _isVillageUnderAttack;

        private void Awake()
        {
            Instance = this;
            _allAgents = new List<AgentWorker>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.KeypadPlus))
            {
                foreach (var worker in _allAgents)
                {
                    worker.AddExtraBehavior();
                }
            }
            if (Input.GetKeyDown(KeyCode.KeypadMinus))
            {
                foreach (var worker in _allAgents)
                {
                    worker.RemoveExtraBehavior();
                }
            }
        }

        public void AddToTotalWood(int wood)
        {
            Wood = Mathf.Clamp(Wood + wood, 0, int.MaxValue);
            CanvasesUI.Instance.StatsUI.SetWoodCount(Wood);
        }

        public void ReadyForDuty(AgentWorker agentWorker)
        {
            WorkersCount++;
            CanvasesUI.Instance.StatsUI.SetWorkerCount(WorkersCount);
            _allAgents.Add(agentWorker);
        }

        private void Defend()
        {
            foreach (var worker in _allAgents)
            {
                worker.Defend();
            }
        }

        private void Work()
        {
            foreach (var worker in _allAgents)
            {
                worker.Work();
            }
        }

        public void WorkerDied()
        {
            WorkersCount--;
            CanvasesUI.Instance.StatsUI.SetWorkerCount(WorkersCount);
        }
    }
}
