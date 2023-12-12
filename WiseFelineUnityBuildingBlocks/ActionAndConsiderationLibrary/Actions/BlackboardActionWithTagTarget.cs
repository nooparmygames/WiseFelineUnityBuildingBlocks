using NoOpArmy.UtilityAI.Actions;
using NoOpArmy.WiseFeline;
using NoOpArmy.WiseFeline.AITags;
using NoOpArmy.WiseFeline.BlackBoards;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NoOpArmy.UtilityAI.Actions
{
    /// <summary>
    /// This action updates its targets based on AI tags system and executes blackboard changes which you choose.
    /// The action doesn't do anything with the targets but will not execute if one of the targets don't get a high score.
    /// You need at least one consideration with NeedTarget set to true for this to evaluate the targets.
    /// </summary>
    public class BlackboardActionWithTagTarget : BlackboardActionBase
    {
        /// <summary>
        /// The radius of the search for tags
        /// </summary>
        [Header("Search properties")]
        [Tooltip("The radius of the search for tags")]
        public float radius = 100;

        /// <summary>
        /// Tags which at least one of them should be in the AITags component of the object to be considered a valid target.
        /// </summary>
        [Tooltip("Tags which at least one of them should be in the AITags component of the object to be considered a valid target.")]
        public string[] includedTags;

        /// <summary>
        /// Tags which if any of them are on the AITags component of the object, the object cannot be considered a potential target
        /// </summary>
        [Tooltip("Tags which if any of them are on the AITags component of the object, the object cannot be considered a potential target")]
        public string[] excludedTags;

        
        protected override void UpdateTargets()
        {
            ClearTargets();
            AddTargets(AITagsManager.Instance.GetTagsAroundPoint(Brain.transform.position, radius, includedTags, excludedTags));
        }
    }
}
