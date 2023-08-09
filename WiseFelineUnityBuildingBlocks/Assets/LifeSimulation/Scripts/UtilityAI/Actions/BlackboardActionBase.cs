using NoOpArmy.WiseFeline;
using NoOpArmy.WiseFeline.BlackBoards;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NoOpArmy.UtilityAI.Actions
{
    /// <summary>
    /// Actions which want to do some blackboard changes along side their custom code can derive from this
    /// </summary>
    public class BlackboardActionBase : ActionBase
    {

        /// <summary>
        /// The change you want to happen to the blackboard during this action
        /// </summary>
        [Tooltip("The change you want to happen to the blackboard during this action")]
        public BlackBoardChangeer changer;

        /// <summary>
        /// Used for the once change type
        /// </summary>
        private int executionCount;

        /// <summary>
        /// The last time this got executed, used for delay based changes
        /// </summary>
        private float lastExecutionTime;

        /// <summary>
        /// The blackboard to use for changes
        /// </summary>
        private BlackBoard blackBoard;

        protected override void OnStart()
        {
            base.OnStart();
            blackBoard = Brain.GetComponent<BlackBoard>();
        }

        protected override void OnUpdate()
        {
            base.OnUpdate();
            if (changer.changeType == BlackBoardChangeer.ChangeType.None)
                return;
            if (changer.changeType == BlackBoardChangeer.ChangeType.Once && executionCount == 0)
            {
                executionCount++;
                changer.change.AddOrSetToBlackBoard(blackBoard);

            }
            else if (changer.changeType == BlackBoardChangeer.ChangeType.RepeatWithDelay && Time.time - lastExecutionTime >= changer.delay)
            {
                if ((changer.maxExecutionCount == 0 || executionCount < changer.maxExecutionCount))
                {
                    executionCount++;
                    lastExecutionTime = Time.time;
                    changer.change.AddOrSetToBlackBoard(blackBoard);
                }
            }
        }



        protected override void UpdateTargets()
        {

        }
    }
}
