using NoOpArmy.WiseFeline;
using NoOpArmy.WiseFeline.AITags;
using UnityEngine;

namespace NoOpArmy.UtilityAI.Actions
{
    /// <summary>
    /// Destroys the target object, can be used for killing, eating and similar actions
    /// It finds the target to destroy using the tags manager and the tags specified in the action
    /// </summary>
    public class DestroyTargetWithTagAction : BlackboardActionBase
    {
        private float startTime;

        public float radius = 100;

        /// <summary>
        /// The tags which existence of any of them on the target object means it is a valid target
        /// </summary>
        [Tooltip("The tags which existence of any of them on the target object means it is a valid target")]
        public string[] includedTags;

        /// <summary>
        /// The tags which existence of any of them on the target object means it is an invalid target
        /// </summary>
        [Tooltip("The tags which existence of any of them on the target object means it is an invalid target")]
        public string[] excludedTags;

        /// <summary>
        /// How much time should pass before destruction happens
        /// </summary>
        [Tooltip("How much time should pass before destruction happens")]
        public float delayForDestruction = 0;

        protected override void UpdateTargets()
        {
            ClearTargets();
            AddTargets(AITagsManager.Instance.GetTagsAroundPoint(Brain.transform.position, radius, includedTags, excludedTags));
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
                    GameObject.Destroy(ChosenTarget.gameObject);
                    ActionSucceeded();
                }
                else //Something else already destroyed that object
                {
                    ActionFailed();
                }
            }
        }
    }
}