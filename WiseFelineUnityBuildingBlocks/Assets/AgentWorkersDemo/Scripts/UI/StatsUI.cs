using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace NoOpArmy.WiseFeline.Sample
{
    public class StatsUI : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _workerCount;
        [SerializeField]
        private TextMeshProUGUI _woodCount;

        public void SetWorkerCount(int count)
        {
            _workerCount.SetText(count.ToString());
        }

        public void SetWoodCount(int count)
        {
            _woodCount.SetText(count.ToString());
        }
    }
}
