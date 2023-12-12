using NoOpArmy.WiseFeline;
using UnityEngine;

namespace NoOpArmy.UtilityAI.Considerations
{
    /// <summary>
    /// Checks if we have a line of sight to our target or something blocks the view
    /// </summary>
    public class LineOfSightConsideration : ConsiderationBase
    {
        /// <summary>
        /// The layer mask for the raycast
        /// </summary>
        [Tooltip("The layer mask for the raycast")]
        public LayerMask layerMask;
        
        protected override float GetValue(Component target)
        {
            // Get the target transform
            Transform targetTransform = target.transform;

            // Get the direction to the target
            Vector3 direction = targetTransform.position - Brain.transform.position;

            // Check if there is anything blocking the view
            RaycastHit hit;
            if (Physics.Raycast(Brain.transform.position, direction, out hit, Mathf.Infinity, layerMask))
            {
                // If the hit object is not the target, return 0
                if (hit.transform != targetTransform)
                {
                    return 0f;
                }
            }

            // Otherwise, return 1
            return 1f;
        }
    }

}