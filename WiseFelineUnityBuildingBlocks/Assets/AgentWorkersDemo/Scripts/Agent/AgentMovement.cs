using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace NoOpArmy.WiseFeline.Sample
{
    public class AgentMovement : MonoBehaviour
    {
        [SerializeField]
        private Home _home;

        public Vector3 Destination { get { return _navAgent.destination; } }

        private NavMeshAgent _navAgent;
        private Action _reachCallback;

        private void Awake()
        {
            _navAgent = GetComponent<NavMeshAgent>();
        }

        public void GoToHome(Action callback)
        {
            MoveTo(_home.transform.position, callback);
        }

        public void MoveTo(Vector3 position, Action callback = null)
        {
            _reachCallback = callback;
            _navAgent.SetDestination(position);
            _navAgent.isStopped = false;
        }

        public void StopMove()
        {
            _navAgent.isStopped = true;
        }

        private void Update()
        {
            if (_reachCallback != null)
            {
                if (IsReached())
                {
                    _reachCallback.Invoke();
                    _reachCallback = null;
                }
            }
        }

        private bool IsReached()
        {
            if (!_navAgent.pathPending)
            {
                if (_navAgent.remainingDistance <= _navAgent.stoppingDistance)
                {
                    if (!_navAgent.hasPath || _navAgent.velocity.sqrMagnitude == 0f)
                    {
                        _navAgent.isStopped = true;
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
