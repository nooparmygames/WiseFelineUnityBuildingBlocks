using NoOpArmy.WiseFeline;
using NoOpArmy.WiseFeline.AITags;
using UnityEngine;

namespace NoOpArmy.UtilityAI.Actions
{
    /// <summary>
    /// Makes a list of potential targets using the AI Tag system and moves toward the chosen target if the action is selected to execute.
    /// Needs a consideration with NeedTarget set so targets can be evaluated and chosen.
    /// </summary>
    public class MoveToTargetWithTag : BlackboardActionBase
    {
        private IAIMovement agentMovement;

        /// <summary>
        /// The radius of the search
        /// </summary>
        [Tooltip("The radius of the search")]
        public float radius = 100;

        /// <summary>
        /// Tags which at least one of them should be present on the AITags component of the object to be a potential target.
        /// </summary>
        public string[] includedTags;

        /// <summary>
        /// Tags which none of them should be present on the AITags component of the object to be a potential target.
        /// </summary>
        public string[] excludedTags;

        protected override void OnInitialized()
        {
            base.OnInitialized();
            agentMovement = Brain.GetComponent<IAIMovement>();
        }

        protected override void OnStart()
        {
            base.OnStart();

            if (!agentMovement.MoveToPosition(ChosenTarget.transform.position, ReachToDistanceSuccessfully))
                ActionFailed();

        }

        void ReachToDistanceSuccessfully()
        {
            ActionSucceeded();
        }

        protected override void UpdateTargets()
        {
            ClearTargets();
            AddTargets(AITagsManager.Instance.GetTagsAroundPoint(Brain.transform.position, radius, includedTags, excludedTags));
        }
    }
}