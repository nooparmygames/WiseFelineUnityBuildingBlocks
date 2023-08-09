using NoOpArmy.WiseFeline;
using NoOpArmy.WiseFeline.BlackBoards;
using NoOpArmy.WiseFeline.Sample;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace NoOpArmy.UtilityAI.Sample
{
    public class MainAgent : MonoBehaviour
    {
        public float energy = 100;

        void Start()
        {
            GetComponent<BlackBoard>().SetVector3("bedposition", new Vector3(-8.5f, 1.083333f, -8.5f));
            GetComponent<BlackBoard>().SetVector3("doorposition", new Vector3(8.5f, 1.083333f, -8.5f));
            GetComponent<BlackBoard>().SetVector3("workposition", new Vector3(-6.5f, 1.083333f, -8.5f));
            GetComponent<BlackBoard>().SetVector3("showerposition", new Vector3(-0.45f, 1.083333f, -8.5f));
            GetComponent<BlackBoard>().SetVector3("bathroomposition", new Vector3(-2.5f, 1.083333f, -8.5f));
            GetComponent<BlackBoard>().SetVector3("kitchenposition", new Vector3(-2f, 1.083333f, 7.7f));
            GetComponent<BlackBoard>().SetVector3("cookingposition", new Vector3(-8.5f, 1.083333f, 7.7f));
            GetComponent<BlackBoard>().SetFloat("energy", energy);
            GetComponent<BlackBoard>().SetBool("workdone", false);
            GetComponent<BlackBoard>().SetBool("food", false);
            GetComponent<BlackBoard>().SetBool("foodmaterial", false);
            GetComponent<BlackBoard>().SetBool("shower", false);
        }

        void Update()
        {
        
        }
    }
}
