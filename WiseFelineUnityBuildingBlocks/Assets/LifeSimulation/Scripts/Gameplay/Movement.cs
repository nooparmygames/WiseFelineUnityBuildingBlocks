using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace NoOpArmy.WiseFeline.Sample
{
    public class Movement : MonoBehaviour
    {

        public Vector3 Destination { get { return navAgent.destination; } }

        private NavMeshAgent navAgent;
        private Action reachCallback;

        private void Awake()
        {
            navAgent = GetComponent<NavMeshAgent>();
        }

        public void MoveToPosition(Vector3 position, Action callback = null)
        {
            reachCallback = callback;
            navAgent.SetDestination(position);
        }

        public void StopMove()
        {
            navAgent.isStopped = true;
        }

        private void Update()
        {
            if (reachCallback != null)
            {
                if (IsReached())
                {
                    reachCallback.Invoke();
                    reachCallback = null;
                }
            }
        }

        private bool IsReached()
        {
            if (!navAgent.pathPending)
            {
                if (navAgent.remainingDistance <= navAgent.stoppingDistance)
                {
                    if (!navAgent.hasPath || navAgent.velocity.sqrMagnitude == 0f)
                    {
                        navAgent.isStopped = true;
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
