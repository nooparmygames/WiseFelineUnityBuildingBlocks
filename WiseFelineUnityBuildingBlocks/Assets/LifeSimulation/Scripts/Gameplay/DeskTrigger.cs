using NoOpArmy.UtilityAI.Sample;
using NoOpArmy.WiseFeline;
using System;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class DeskTrigger : MonoBehaviour
{
    private ActionBase action;
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out MainAgent mainAgent))
        {
            mainAgent.OnWorkSuccess(action);
        }
    }
}