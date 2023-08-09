using NoOpArmy.UtilityAI.Sample;
using NoOpArmy.WiseFeline;
using NoOpArmy.WiseFeline.BlackBoards;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class BedTrigger : MonoBehaviour
{
    private ActionBase action;
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out MainAgent mainAgent))
        {
            mainAgent.OnSleepSuccess(action);
        }
    }
}