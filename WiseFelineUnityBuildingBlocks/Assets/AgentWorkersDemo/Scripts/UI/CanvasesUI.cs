using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NoOpArmy.WiseFeline.Sample
{
    public class CanvasesUI : MonoBehaviour
    {
        public static CanvasesUI Instance;
        [SerializeField]
        private StatsUI _statsUI;

        public StatsUI StatsUI { get { return _statsUI; } }

        private void Awake()
        {
            Instance = this;
        }
    }
}
