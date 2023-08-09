using NoOpArmy.UtilityAI.Sample;
using NoOpArmy.WiseFeline;
using NoOpArmy.WiseFeline.BlackBoards;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class KitchenDeskTrigger : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out MainAgent mainAgent))
        {
            mainAgent.GetComponent<BlackBoard>().SetFloat("energy", 20f);
            mainAgent.GetComponent<BlackBoard>().SetFloat("havingpee", 100f);
            mainAgent.GetComponent<BlackBoard>().SetBool("food", false);
        }
    }
}