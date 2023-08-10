using System.Collections;
using System.Collections.Generic;
using NoOpArmy.WiseFeline.BlackBoards;
using UnityEngine;
using TMPro;
using NoOpArmy.UtilityAI.Sample;

namespace NoOpArmy.WiseFeline.Sample
{
    public class StatusUI : MonoBehaviour
    {
        [SerializeField]
        private MainAgent mainAgent;
        [SerializeField]
        private TextMeshProUGUI energyValue;
        [SerializeField]
        private TextMeshProUGUI hungerValue;
        [SerializeField]
        private TextMeshProUGUI messyValue;
        [SerializeField]
        private TextMeshProUGUI foodValue;
        [SerializeField]
        private TextMeshProUGUI materialValue;

        private void Update()
        {
            energyValue.text = mainAgent.GetComponent<BlackBoard>().GetFloat("energy").ToString();
            hungerValue.text = mainAgent.GetComponent<BlackBoard>().GetFloat("hunger").ToString();
            messyValue.text = mainAgent.GetComponent<BlackBoard>().GetFloat("messy").ToString();
            foodValue.text = mainAgent.GetComponent<BlackBoard>().GetBool("food").ToString();
            materialValue.text = mainAgent.GetComponent<BlackBoard>().GetBool("foodmaterial").ToString();
        }
    }
}
