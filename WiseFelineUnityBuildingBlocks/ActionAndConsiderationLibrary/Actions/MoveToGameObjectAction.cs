using UnityEngine;
using NoOpArmy.WiseFeline;

namespace NoOpArmy.UtilityAI.Actions
{

    /// <summary>
    /// Moves the agent to the position of a GameObject set on a blackboard key.
    /// </summary>
    public class MoveToGameObjectAction : BlackboardActionBase
    {
        private IAIMovement agentMovement;

        /// <summary>
        /// Name of the GameObject key in the blackboard
        /// </summary>
        [Tooltip("Name of the GameObject key in the blackboard")]
        public string gameObjectKeyName;

        protected override void OnInitialized()
        {
            base.OnInitialized();
            agentMovement = Brain.GetComponent<IAIMovement>();
        }

        protected override void OnStart()
        {
            base.OnStart();

            if (!agentMovement.MoveToPosition(blackBoard.GetGameObject(gameObjectKeyName), ReachToDistanceSuccessfully))
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