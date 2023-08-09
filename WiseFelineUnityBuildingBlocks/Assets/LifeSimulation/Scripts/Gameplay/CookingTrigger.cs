using NoOpArmy.UtilityAI.Sample;
using NoOpArmy.WiseFeline;
using NoOpArmy.WiseFeline.BlackBoards;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class CookingTrigger : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out MainAgent mainAgent))
        {
            mainAgent.GetComponent<BlackBoard>().SetFloat("energy", 30f);
            mainAgent.GetComponent<BlackBoard>().SetFloat("hunger", 50f);
            mainAgent.GetComponent<BlackBoard>().SetBool("food", true);
            mainAgent.GetComponent<BlackBoard>().SetBool("foodmaterial", false);
        }
    }
}