using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace NoOpArmy.WiseFeline.Sample
{
    public class ResourcesUI : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _countText;

        public void UpdateAmount(float amount)
        {
            _countText.SetText(Mathf.Round(amount).ToString());
        }
    }
}
