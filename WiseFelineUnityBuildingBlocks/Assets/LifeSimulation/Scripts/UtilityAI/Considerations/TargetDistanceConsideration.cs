using NoOpArmy.WiseFeline;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NoOpArmy.UtilityAI.Considerations
{
    public class TargetDistanceConsideration : ConsiderationBase
    {

        /// <summary>
        /// Minimum acceptable distance
        /// </summary>
        [Tooltip("Minimum acceptable distance")]
        public float minDistance = 0;

        /// <summary>
        /// Max acceptable distance
        /// </summary>
        [Tooltip("Max acceptable distance")]
        public float maxDistance = 100;

        /// <summary>
        /// The consideration will return this value if the distance is higher than max distance
        /// </summary>
        [Tooltip("The consideration will return this value if the distance is higher than max distance")]
        public float valueForDistancesHigherThanMax = 0;

        /// <summary>
        /// The consideration will return this value if the distance is lower than min distance
        /// </summary>
        [Tooltip("The consideration will return this value if the distance is lower than min distance")]
        public float valueForDistancesLowerThanMin = 0;

        protected override float GetValue(Component target)
        {
            if (target == null)
                return 0;
            var d = Vector3.Distance(Brain.transform.position, target.transform.position);
            if (d > maxDistance)
                return valueForDistancesHigherThanMax;

            if (d < minDistance)
                return valueForDistancesLowerThanMin;
            return (d - minDistance) / (maxDistance - minDistance);
        }
    }
}
