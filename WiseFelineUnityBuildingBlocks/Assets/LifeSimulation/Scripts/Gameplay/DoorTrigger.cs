using NoOpArmy.UtilityAI.Sample;
using NoOpArmy.WiseFeline;
using NoOpArmy.WiseFeline.BlackBoards;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    private ActionBase action;
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out MainAgent mainAgent))
        {
            mainAgent.gameObject.GetComponentInChildren<Renderer>().enabled = false;
            mainAgent.OnGoToShopSuccess(action);
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
