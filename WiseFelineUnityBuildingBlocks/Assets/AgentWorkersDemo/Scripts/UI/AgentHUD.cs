using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NoOpArmy.WiseFeline.Sample
{
    public class AgentHUD : MonoBehaviour
    {
        [SerializeField]
        private Canvas _canvas;
        public ResourcesUI HealthUI;
        public ResourcesUI EnergyUI;

        private void Start()
        {
            _canvas.worldCamera = Camera.main;
        }
    }
}
