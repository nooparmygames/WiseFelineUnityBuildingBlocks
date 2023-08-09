using NoOpArmy.WiseFeline;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace NoOpArmy.UtilityAI.Actions
{
    /// <summary>
    /// This action creates gameobjects, can be used for shooting, providing loot and other similar things
    /// </summary>
    public class CreateGameObjectAction : BlackboardActionBase
    {
        private float startTime;

        /// <summary>
        /// Delay to create an object
        /// </summary>
        [Tooltip("Delay to create an object")]
        public float creationDelay;

        /// <summary>
        /// The GameObject to create
        /// </summary>
        [Tooltip("The GameObject to create")]
        public GameObject objectToCreate;

        /// <summary>
        /// How many object to create
        /// </summary>
        [Tooltip("How many object to create")]
        public int objectCountToCreate = 1;

        /// <summary>
        /// Should we create all objects at the same time or once after each delay
        /// </summary>
        [Tooltip("Should we create all objects at the same time or once after each delay")]
        public bool createAtTheSameTime;

        /// <summary>
        /// Is the position specified from origin or the psoition of the executing game object.
        /// </summary>
        [Tooltip("Is the position specified from origin or the psoition of the executing game object.")]
        public bool isPositionRelative;

        /// <summary>
        /// The position to create the object
        /// </summary>
        [Tooltip("The position to create the object")]
        public Vector3 creationPosition;

        protected override void UpdateTargets()
        {

        }

        protected override void OnUpdate()
        {
            base.OnUpdate();
            if (objectCountToCreate == 0)
            {
                return;
            }

            if (Time.time - startTime >= creationDelay)
            {
                if (!createAtTheSameTime)
                {
                    Create();
                    objectCountToCreate--;
                    startTime = Time.time;
                }
                else
                {
                    for (int i = 0; i < objectCountToCreate; i++)
                    {
                        Create();
                    }
                    startTime = 0;
                    objectCountToCreate = 0;
                }
                if (objectCountToCreate == 0)
                    ActionSucceed();
            }
        }

        protected override void OnStart()
        {
            base.OnStart();
            startTime = Time.time;
        }

        private void Create()
        {
            Vector3 pos;
            if (isPositionRelative)
            {
                pos = Brain.transform.transform.position + creationPosition;
            }
            else
            {
                pos = creationPosition;
            }
            GameObject.Instantiate(objectToCreate, creationPosition, Quaternion.identity);
        }
    }
}
