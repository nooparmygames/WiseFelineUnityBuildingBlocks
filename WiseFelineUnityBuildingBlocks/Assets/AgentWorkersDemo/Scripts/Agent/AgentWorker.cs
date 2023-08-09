using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NoOpArmy.WiseFeline.Sample
{
    public class AgentWorker : AgentController
    {
        public float Energy
        {
            get { return _energy; }
            set
            {
                _energy = Mathf.Clamp(value, 0, 100);
                _agentHUD.EnergyUI.UpdateAmount(_energy);
            }
        }
        private float _energy;

        [SerializeField]
        private AgentBehavior _extraBehavior;

        private Brain _brainComponent;

        protected override void Awake()
        {
            base.Awake();
            _brainComponent = GetComponent<Brain>();
            _energy = 100;
        }

        protected override void Start()
        {
            GameManager.Instance.ReadyForDuty(this);
        }

        public override void Rest(float energy)
        {
            Energy += energy;
            _agentHUD.EnergyUI.UpdateAmount(Energy);
        }

        public void Defend()
        {
            
        }

        public void Work()
        {
            
        }

        public void AddExtraBehavior()
        {
            _brainComponent.AddBehavior(_extraBehavior);
        }

        public void RemoveExtraBehavior()
        {
            _brainComponent.RemoveBehavior(_extraBehavior);
        }
    }
}
