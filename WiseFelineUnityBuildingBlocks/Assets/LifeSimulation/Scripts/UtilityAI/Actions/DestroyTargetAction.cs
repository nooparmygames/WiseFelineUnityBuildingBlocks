using NoOpArmy.WiseFeline;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NoOpArmy.UtilityAI.Actions
{
    /// <summary>
    /// Destroys the target object, can be used for killing, eating and similar actions
    /// </summary>
    public class DestroyTargetAction : BlackboardActionBase
    {
        private float startTime;

        /// <summary>
        /// How much time should happen before destruction happens
        /// </summary>
        [Tooltip("How much time should happen before destruction happens")]
        public float delayForDestruction = 0;

        protected override void UpdateTargets()
        {

        }


        protected override void OnStart()
        {
            base.OnStart();
            startTime = Time.time;
        }

        protected override void OnUpdate()
        {
            base.OnUpdate();
            if (Time.time - startTime >= delayForDestruction)
            {
                if (ChosenTarget != null)
                {
                    GameObject.Destroy(ChosenTarget);
                    ActionSucceed();
                }
            }
        }
    }
}
