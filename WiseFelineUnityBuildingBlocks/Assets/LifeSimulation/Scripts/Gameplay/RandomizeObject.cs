using NoOpArmy.WiseFeline.BlackBoards;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace NoOpArmy.UtilityAI.Sample
{
    public class RandomizeObject : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            transform.localScale = Vector3.one * (Random.value + 0.2f);
            transform.Translate(0, Random.value * 3, Random.value * 5);
        }

        

    }
}
