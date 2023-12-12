using NoOpArmy.WiseFeline;
using NoOpArmy.WiseFeline.BlackBoards;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NoOpArmy.UtilityAI.Considerations
{
    /// <summary>
    /// Checks an integer key in the blackboard and returns its value. If the key doesn't exist then it returns 0
    /// </summary>
    public class BlackboardIntRangeConsideration : ConsiderationBase
    {
        /// <summary>
        /// Inverts the consideration's final value (maxRange - value + minRange)
        /// </summary>
        [Tooltip("Inverts the consideration's final value (maxRange - value + minRange)")]
        [SerializeField] bool inverse = false;

        /// <summary>
        /// Name of the key in the blackboard
        /// </summary>
        [Tooltip("Name of the key in the blackboard")]
        public string keyName;

        protected override float GetValue(Component target)
        {
            BlackBoard blackBoard = target.GetComponent<BlackBoard>();
            if (blackBoard != null)
            {
                if (!blackBoard.HasInt(keyName))
                    return 0;

                var value = blackBoard.GetInt(keyName);

                if (!inverse)
                    return value;
                else
                    return maxRange - value - minRange;
            }
            return 0;
        }
    }
}