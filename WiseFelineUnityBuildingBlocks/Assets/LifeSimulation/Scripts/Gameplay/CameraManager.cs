using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace NoOpArmy.UtilityAI.Sample
{
    public class CameraManager : MonoBehaviour
    {
        public Transform agent;
        public float smooth = 5f;
        private Vector3 offset;
        void Start()
        {
            offset = transform.position - agent.position;
        }
        void LateUpdate()
        {
            CameraFollow();
        }

        void CameraFollow()
        {
            Vector3 targetCamPos = agent.position + offset;
            transform.position = Vector3.Lerp(transform.position, targetCamPos, smooth * Time.deltaTime);
        }

    }
}
