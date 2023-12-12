using NoOpArmy.WiseFeline;
using NoOpArmy.WiseFeline.BlackBoards;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NoOpArmy.UtilityAI.Considerations
{
    /// <summary>
    /// Checks afloat key in the blackboard and if it exists, returns its value, otherwise returns 0
    /// </summary>
    public class BlackboardFloatConsideration : ConsiderationBase
    {
        /// <summary>
        /// Inverts the consideration's final value (0.8 --> 0.2)
        /// </summary>
        [Tooltip("Inverts the consideration's final value (0.8 --> 0.2)")]
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
                if (!blackBoard.HasFloat(keyName))
                    return 0;
                var value = blackBoard.GetFloat(keyName);
                if (!inverse)
                    return value;
                else
                    return maxRange - value + minRange;
            }
            return 0;
        }
    }
}