using NoOpArmy.WiseFeline;
using NoOpArmy.WiseFeline.BlackBoards;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NoOpArmy.UtilityAI.Considerations
{
    public class IntBlackboardConsideration : ConsiderationBase
    {
        /// <summary>
        /// Name of the key in the blackboard
        /// </summary>
        [Tooltip("Name of the key in the blackboard")]
        public string keyName;

        /// <summary>
        /// Minimum value which the key can have
        /// </summary>
        [Tooltip("Minimum value which the key can have")]
        public int minValue;

        /// <summary>
        /// Maximum value the key can have
        /// </summary>
        [Tooltip("Maximum value the key can have")]
        public int maxValue;

        protected override float GetValue(Component target)
        {
            BlackBoard blackBoard = target.GetComponent<BlackBoard>();
            if (blackBoard != null)
            {
                var value = blackBoard.GetInt(keyName);
                if (value < minValue)
                    return 0;
                if (value > maxValue)
                    return 1;
                return (value - minValue) / (float)(maxValue - minValue);
            }
            return 0;
        }
    }
}
