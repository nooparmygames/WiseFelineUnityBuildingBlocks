using NoOpArmy.WiseFeline.BlackBoards;
using NoOpArmy.UtilityAI.Actions;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

namespace NoOpArmy.WiseFeline.Sample
{
    public class MoveAndWaitAndChangeFloat : BlackboardActionBase
    {
        private Movement agentMovement;
        private BlackBoard bb;

        [Tooltip("Name of the key in the blackboard")]
        public string positionKeyName;

        [Tooltip("Value which the action should wait")]
        public float waitingTime;
        protected override void OnInitialized()
        {
            agentMovement = Brain.GetComponent<Movement>();
            bb = Brain.GetComponent<BlackBoard>();
        }

        protected override void OnUpdate()
        {
            agentMovement.MoveToPosition(bb.GetVector3(positionKeyName), null);
            if (waitingTime > 0)
            {
                waitingTime -= Time.deltaTime;
                if (waitingTime <= 0)
                {
                    ActionSucceed();
                }
            }
        }

        protected override void UpdateTargets()
        {

        }
    }
}