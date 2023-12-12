using NoOpArmy.WiseFeline;
using NoOpArmy.WiseFeline.SmartObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NoOpArmy.UtilityAI.Considerations
{
    /// <summary>
    /// Returns the distance to a target which is a smart object.
    /// You can choose to get the distance to a specific slot with a specific condition like the distance to the closes slot which is free.
    /// </summary>
    public class SmartObjectDistanceConsideration : ConsiderationBase
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

        /// <summary>
        /// If true, score is computed using the best slot position, not the smart object position.
        /// </summary>
        [Tooltip("If true, score is computed using the best slot position, not the smart object position.")]
        public bool useNearestSlotPosition = false;

        /// <summary>
        /// The search query to use for finding the smart object if useNearestSlotPosition is true
        /// </summary>
        [Tooltip("The search query to use for finding the smart object if useNearestSlotPosition is true")]
        public SmartObjectsManager.SearchQueryOptions SlotStatus;

        protected override float GetValue(Component target)
        {
            if (target == null)
                return 0f;
            else
            {
                Vector3 targetpos;
                Vector3 brainPos = Brain.transform.position;

                if (!useNearestSlotPosition)
                {
                    targetpos = target.transform.position;
                }
                else
                {
                    SmartObject smartObject = target as SmartObject;

                    //if the target is not a smart object
                    if (smartObject == null)
                        return 0;

                    targetpos = smartObject.GetClosestSlotPosition(Brain.gameObject, SlotStatus);
                }


                if (calculateOnXZPlane)
                    targetpos.y = brainPos.y;

                var d = Vector3.Distance(brainPos, targetpos);

                if (!inverse)
                    return d;
                else
                    return maxRange - d + minRange;
            }
        }
    }
}