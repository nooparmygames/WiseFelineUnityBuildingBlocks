using NoOpArmy.WiseFeline;
using NoOpArmy.WiseFeline.BlackBoards;
using UnityEngine;

namespace NoOpArmy.UtilityAI.Considerations
{
    /// <summary>
    /// Checks a boolean key in a blackboard. This reutnrs 1 if the key exists and is true and if it doesn't exist or is false returns 0.
    /// </summary>
    public class BlackboardBoolConsideration : ConsiderationBase
    {
        /// <summary>
        /// Name of the boolean key to check
        /// </summary>
        [Tooltip("Name of the boolean key to check")]
        public string keyName;

        protected override float GetValue(Component target)
        {
            BlackBoard blackBoard = target.GetComponent<BlackBoard>();
            if (blackBoard != null)
            {
                if (!blackBoard.HasBool(keyName))
                    return 0;
                var value = blackBoard.GetBool(keyName);
                return value == true ? 1 : 0;
            }
            return 0;
        }
    }
}