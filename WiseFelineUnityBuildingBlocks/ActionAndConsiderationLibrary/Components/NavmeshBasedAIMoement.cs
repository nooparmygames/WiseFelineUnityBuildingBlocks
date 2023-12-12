using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace NoOpArmy.WiseFeline
{
    /// <summary>
    /// Movement component allows you to move an agent on the NavMesh. This component implements the IAIMovement interface so generic actions can use it.
    /// </summary>
    [RequireComponent(typeof(NavMeshAgent))]
    public class NavmeshBasedAIMoement : MonoBehaviour, IAIMovement
    {
        public Vector3 Destination
        {
            get { return navAgent.destination; }
            set { navAgent.destination = value; }
        }

        private NavMeshAgent navAgent;
        private Action reachCallback;

        public string animatorSpeedParameter;
        Animator animator;

        private void Awake()
        {
            navAgent = GetComponent<NavMeshAgent>();
            animator = GetComponentInChildren<Animator>();
        }

        /// <summary>
        /// Moves the agent to a position
        /// </summary>
        /// <param name="position"></param>
        /// <param name="callback"></param>
        /// 

        public bool MoveToPosition(Vector3 position, Action callback)
        {

            reachCallback = callback;
            var setDestinationResult = navAgent.SetDestination(position);
            if (!setDestinationResult)
            {
                Debug.Log("PROBLEEEEEM");
            }
            return setDestinationResult;

        }


        public bool MoveToPosition(GameObject go, System.Action callback)
        {

            reachCallback = callback;
            return navAgent.SetDestination(go.transform.position);
        }


        public void StopMoving()
        {
            try
            {
                navAgent.SetDestination(transform.position);
            }
            catch
            {
                // Because "SetDestination" can only be called on an active agent that has been placed on a NavMesh.
            }
        }

        private void Update()
        {
            if (animator != null && !string.IsNullOrEmpty(animatorSpeedParameter))
            {
                animator.SetFloat(animatorSpeedParameter, navAgent.velocity.magnitude / navAgent.speed);
            }

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
            if (!navAgent.pathPending && navAgent.enabled)
            {
                if (navAgent.remainingDistance <= navAgent.stoppingDistance)
                {
                    if (!navAgent.hasPath || navAgent.velocity.sqrMagnitude == 0f)
                    {
                        //navAgent.isStopped = true;
                        return true;
                    }
                }
            }
            return false;
        }


    }
}