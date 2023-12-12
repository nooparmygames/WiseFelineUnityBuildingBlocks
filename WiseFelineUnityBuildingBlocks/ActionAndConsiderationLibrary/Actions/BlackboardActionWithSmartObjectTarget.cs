using NoOpArmy.UtilityAI.Actions;
using NoOpArmy.WiseFeline;
using NoOpArmy.WiseFeline.AITags;
using NoOpArmy.WiseFeline.BlackBoards;
using NoOpArmy.WiseFeline.SmartObjects;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;

namespace NoOpArmy.UtilityAI.Actions
{
    /// <summary>
    /// Finds potential targets from smart objects and optionally claims and uses them. It frees them inOnFinish if the claiming and using is on.
    /// Also the action will fail if it tries to claim/use the smart object unsuccessfully.
    /// </summary>
    public class BlackboardActionWithSmartObjectTarget : BlackboardActionBase
    {
        /// <summary>
        /// The tags which at least one of them should be on the smart object so it is included in the search results
        /// </summary>
        [Tooltip("The tags which at least one of them should be on the smart object so it is included in the search results")]
        public string[] includedTags;

        /// <summary>
        /// The tags which if one of them is on the smart object, it is excluded from the search
        /// </summary>
        [Tooltip("The tags which if one of them is on the smart object, it is excluded from the search")]
        public string[] excludedTags;
        
        /// <summary>
        /// Radius of the search for smart objects
        /// </summary>
        public float searchRadius = 100;

        /// <summary>
        /// Finds smart objects with the chosen slot status.
        /// </summary>
        [Tooltip("Finds smart objects with the chosen slot status.")]
        public SmartObjectsManager.SearchQueryOptions SlotStatus;

        /// <summary>
        /// Should the action claim and use the smart object in OnStart and then Free the object in OnFinish?
        /// </summary>
        [Tooltip("Should the action claim and use the smart object in OnStart and then Free the object in OnFinish?")]
        public bool ClaimAndUseSmartObject = false;

        protected override void OnStart()
        {
            base.OnStart();
            var smartobject = ChosenTarget as SmartObject;

            if (ClaimAndUseSmartObject)
            {
                int slotIndex = smartobject.GetFirstOwnedSlotIndex(Brain.gameObject);

                if (slotIndex == -1)
                    slotIndex = smartobject.GetFreeSlotIndex();

                if (slotIndex == -1 && SlotStatus == SmartObjectsManager.SearchQueryOptions.None)
                    slotIndex = 0;

                if (smartobject.Claim(slotIndex, Brain.gameObject))
                {
                    if(smartobject.Use(slotIndex, Brain.gameObject))
                    {

                    }
                    else
                    {
                        ActionFailed();
                    }
                }
                else
                {
                    ActionFailed();
                }
            }
        }

        protected override void UpdateTargets()
        {
            ClearTargets();

            base.UpdateTargets();
            var results = SmartObjectsManager.Instance.GetSmartObjectsAroundPoint(Brain.transform.position, searchRadius, null, SlotStatus, Brain.gameObject, includedTags, excludedTags);

            for (int i = 0; i < results.Count; i++)
            {
                (SmartObject smartObject, SmartObject.FilterResult data) item = results[i];
                AddTarget(item.smartObject);
            }
        }

        protected override void OnFinish()
        {
            base.OnFinish();

            if (ClaimAndUseSmartObject)
            {
                var smartobject = ChosenTarget as SmartObject;

                smartobject.Free(Brain.gameObject);
            }
        }
    }
}