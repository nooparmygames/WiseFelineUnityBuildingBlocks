using NoOpArmy.UtilityAI.Sample;
using NoOpArmy.WiseFeline;
using NoOpArmy.WiseFeline.BlackBoards;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ShowerTrigger : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out MainAgent mainAgent))
        {
            mainAgent.GetComponent<BlackBoard>().SetFloat("messy", 0f);
            mainAgent.GetComponent<BlackBoard>().SetBool("shower", true);
        }
    }
}