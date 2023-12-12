using NoOpArmy.WiseFeline;
using NoOpArmy.WiseFeline.BlackBoards;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NoOpArmy.UtilityAI.Considerations
{
    /// <summary>
    /// This consideration checks an int key in the blackboard and returns 1 if the value equals the expected value; otherwise, it returns 0.
    /// </summary>
    public class BlackboardIntValueConsideration : ConsiderationBase
    {

        /// <summary>
        /// Name of the key in the blackboard
        /// </summary>
        [Tooltip("Name of the key in the blackboard")]
        public string keyName;

        /// <summary>
        /// The consideration returns 1 if the value equals the expected value; otherwise, it returns 0.
        /// </summary>
        [Tooltip("The consideration returns 1 if the value equals the expected value; otherwise, it returns 0.")]
        public int expectedValue;

        protected override float GetValue(Component target)
        {
            BlackBoard blackBoard = target.GetComponent<BlackBoard>();
            if (blackBoard != null)
            {
                if (!blackBoard.HasInt(keyName))
                    return 0;

                var value = blackBoard.GetInt(keyName);

                if (value == expectedValue)
                    return 1;

                return 0;
            }
            return 0;
        }
    }
}
