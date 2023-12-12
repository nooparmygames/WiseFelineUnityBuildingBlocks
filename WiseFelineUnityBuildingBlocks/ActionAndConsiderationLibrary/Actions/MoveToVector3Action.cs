using UnityEngine;
using NoOpArmy.WiseFeline;
using NoOpArmy.WiseFeline.BlackBoards;
using System;

namespace NoOpArmy.UtilityAI.Actions
{
    /// <summary>
    /// Moves the agent to the position of a Vector3 set on a blackboard key.
    /// </summary>
    public class MoveToVector3Action : BlackboardActionBase
    {
        private IAIMovement agentMovement;

        /// <summary>
        /// Name of the Vector3 key in the blackboard
        /// </summary>
        [Tooltip("Name of the Vector3 key in the blackboard")]
        public string positionKeyName;

        protected override void OnInitialized()
        {
            base.OnInitialized();
            agentMovement = Brain.GetComponent<IAIMovement>();
        }

        protected override void OnStart()
        {
            base.OnStart();

            if (!agentMovement.MoveToPosition(blackBoard.GetVector3(positionKeyName), ReachToDistanceSuccessfully))
                ActionFailed();
        }

        void ReachToDistanceSuccessfully()
        {
            ActionSucceeded();
        }

        protected override void UpdateTargets()
        {

        }
    }
}