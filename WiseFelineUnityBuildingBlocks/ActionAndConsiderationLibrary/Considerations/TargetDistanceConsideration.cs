using NoOpArmy.WiseFeline;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NoOpArmy.UtilityAI.Considerations
{
    /// <summary>
    /// Returns the distance to a target. This normalizes to a value between 0 and 1 based on minRange and maxRange values
    /// </summary>
    public class TargetDistanceConsideration : ConsiderationBase
    {
        /// <summary>
        /// Ignore y axis of objects in distance calculations
        /// </summary>
        [Tooltip("Ignore y axis of objects in distance calculations")]
        [SerializeField] bool calculateOnXZPlane = false;

        /// <summary>
        /// Invert the final score ( 0.8 --> 0.2
        /// </summary>
        [Tooltip("Invert the final score ( 0.8 --> 0.2")]
        public bool inverse = false;

        protected override float GetValue(Component target)
        {
            if (target == null)
                return 0f;
            else
            {
                Vector3 objectPos = target.transform.position;
                Vector3 brainPos = Brain.transform.position;

                if (calculateOnXZPlane)
                    objectPos.y = brainPos.y;

                var d = Vector3.Distance(brainPos, objectPos);

                if (!inverse)
                    return d;
                else
                    return maxRange - d + minRange;
            }
        }
    }
}