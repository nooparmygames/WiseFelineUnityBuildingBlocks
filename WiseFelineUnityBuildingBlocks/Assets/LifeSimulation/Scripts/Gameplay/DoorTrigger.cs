using NoOpArmy.UtilityAI.Sample;
using NoOpArmy.WiseFeline;
using NoOpArmy.WiseFeline.BlackBoards;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out MainAgent mainAgent))
        {
            mainAgent.gameObject.GetComponentInChildren<Renderer>().enabled = false;
            mainAgent.GetComponent<BlackBoard>().SetFloat("energy", 40f);
            mainAgent.GetComponent<BlackBoard>().SetBool("workdone", false);
            mainAgent.GetComponent<BlackBoard>().SetBool("foodmaterial", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out MainAgent mainAgent))
        {
            mainAgent.gameObject.GetComponentInChildren<Renderer>().enabled = true;
        }
        
    }
}
