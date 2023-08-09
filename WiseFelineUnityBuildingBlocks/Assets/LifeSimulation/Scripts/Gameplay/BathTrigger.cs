using NoOpArmy.UtilityAI.Sample;
using NoOpArmy.WiseFeline;
using NoOpArmy.WiseFeline.BlackBoards;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class BathTrigger : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out MainAgent mainAgent))
        {
            mainAgent.GetComponent<BlackBoard>().SetFloat("energy", 10f);
            mainAgent.GetComponent<BlackBoard>().SetFloat("havingpee", 0f);
            mainAgent.GetComponent<BlackBoard>().SetFloat("messy", 100f);
        }
    }
}