using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace NoOpArmy.WiseFeline
{


    /// <summary>
    /// This component allows you to move the character to a destination. This component implements the IAIMovement interface so generic actions can use it.
    /// The component uses the CharacterController component to move and does not use path finding and a NavmeshAgent
    /// </summary>
    [RequireComponent(typeof(CharacterController))]
    public class CharacterControllerBasedAIMovement : MonoBehaviour, IAIMovement
    {
        /// <summary>
        /// Movement speed of the character used by the CharacterController.SimpleMove() function
        /// </summary>
        [Tooltip("Movement speed of the character used by the CharacterController.SimpleMove() function")]
        public float speed = 5;

        /// <summary>
        /// The distance to destination which means we arrived
        /// </summary>
        [Tooltip("The distance to destination which means we arrived")]
        public float arrivalDistance = 0.5f;

        public bool CalculateOnXZPlane = false;
        public Vector3 Destination { get; private set; }

        private CharacterController characterController;
        private Action reachCallback;

        bool startMovement = false;

        string animatorSpeedParameter;
        Animator animator;

        private void Awake()
        {
            characterController = GetComponent<CharacterController>();
            animator = GetComponentInChildren<Animator>();
        }

        public bool MoveToPosition(Vector3 position, Action callback)
        {
            Destination = position;
            reachCallback = callback;
            if (Destination != transform.position)
            {
                startMovement = true;
                return true;
            }
            else
                return false;
        }

        public bool MoveToPosition(GameObject target, Action callback)
        {
            Destination = target.transform.position;
            reachCallback = callback;
            if (Destination != transform.position)
            {
                startMovement = true;
                return true;
            }
            else
                return false;
        }

        public void StopMoving()
        {
            startMovement = false;
        }

        private void Update()
        {
            if (startMovement)
            {
                Vector3 direction = (Destination - transform.position).normalized;
                characterController.SimpleMove(direction * speed);

                if (animator != null && !string.IsNullOrEmpty(animatorSpeedParameter))
                {
                    animator.SetFloat(animatorSpeedParameter, characterController.velocity.magnitude);
                }

                if (IsReached())
                {
                    if (reachCallback != null)
                    {
                        reachCallback.Invoke();
                        reachCallback = null;
                    }
                    StopMoving();
                }
            }
        }

        private bool IsReached()
        {
            if (!CalculateOnXZPlane)
                return Vector3.Distance(transform.position, Destination) <= arrivalDistance;
            else
            {
                var destPost = Destination;
                destPost.y = transform.position.y;
                return Vector3.Distance(transform.position, destPost) <= arrivalDistance;
            }
        }
    }
}