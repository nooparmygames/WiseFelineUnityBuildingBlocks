using NoOpArmy.WiseFeline;
using NoOpArmy.WiseFeline.BlackBoards;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NoOpArmy.UtilityAI.Considerations
{
    /// <summary>
    /// Returns the distance between the executing agent and a GameObject which is specified in a key in the blackboard.
    /// </summary>
    public class BlackboardGameObjectDistanceConsideration : ConsiderationBase
    {
        /// <summary>
        /// Name of the key in the blackboard
        /// </summary>
        [Tooltip("Name of the key in the blackboard")]
        public string keyName;

        /// <summary>
        /// Ignore y axis of objects in distance calculations
        /// </summary>
        [Tooltip("Ignore y axis of objects in distance calculations")]
        [SerializeField] bool calculateOnXZPlane = false;

        /// <summary>
        /// Invert the final score (0.8 --> 0.2)
        /// </summary>
        [Tooltip("Invert the final score (0.8 --> 0.2)")]
        [SerializeField] bool inverse = false;

        protected override float GetValue(Component target)
        {
            BlackBoard blackBoard = target.GetComponent<BlackBoard>();
            if (blackBoard != null)
            {
                if (!blackBoard.HasGameObject(keyName))
                    return 0;

                var targetGameobject = blackBoard.GetGameObject(keyName);
                if (targetGameobject == null)
                    return 0f;

                Vector3 objectPos = targetGameobject.transform.position;
                Vector3 brainPos = Brain.transform.position;

                if (calculateOnXZPlane)
                    objectPos.y = brainPos.y;

                var value = Vector3.Distance(objectPos, brainPos);


                if (!inverse)
                    return value;
                else
                    return maxRange - value + minRange;
            }

            return 0;
        }
    }
}