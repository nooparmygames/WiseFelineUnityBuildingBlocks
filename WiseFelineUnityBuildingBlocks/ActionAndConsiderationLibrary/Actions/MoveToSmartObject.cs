using NoOpArmy.WiseFeline;
using System.Collections.Generic;
using UnityEngine;
using NoOpArmy.WiseFeline.SmartObjects;

namespace NoOpArmy.UtilityAI.Actions
{
    /// <summary>
    /// Finds a set of smart objects as potential trgets and if the action gets selected to execute then it moves toward the chosen target.
    /// </summary>
    public class MoveToSmartObject : BlackboardActionBase
    {
        private IAIMovement agentMovement;

        /// <summary>
        /// The tags which at least one of them should be on the smart object to be valid
        /// </summary>
        public string[] includedTags;

        /// <summary>
        /// The tag which none of them should be on the smart object so the object is considered a target.
        /// </summary>
        public string[] excludedTags;

        /// <summary>
        /// Radius of the search for SmartObjects
        /// </summary>
        [Tooltip("Radius of the search for SmartObjects")]
        public float searchRadius = 100;

        /// <summary>
        /// Criteria that the slots should meet to be considered a potential target
        /// </summary>
        public SmartObjectsManager.SearchQueryOptions SlotStatus;
        SmartObject selectedSmartObject;
        int slotIndex;
        protected override void OnInitialized()
        {
            base.OnInitialized();
            agentMovement = Brain.GetComponent<IAIMovement>();
        }

        protected override void OnStart()
        {
            base.OnStart();

            if (ChosenTarget)
            {
                selectedSmartObject = ChosenTarget as SmartObject;
                slotIndex = selectedSmartObject.GetFreeSlotIndex();

                if (slotIndex == -1)
                    ActionFailed();

                if (!agentMovement.MoveToPosition(selectedSmartObject.GetSlotPosition(slotIndex), ReachToDistanceSuccessfully))
                    ActionFailed();
            }
            else
            {
                throw new UnityException("Choosen target is null");
            }

        }

        protected override void UpdateTargets()
        {
            ClearTargets();

            List<(SmartObject smartObject, SmartObject.FilterResult data)> results = SmartObjectsManager.Instance.GetSmartObjectsAroundPoint(Brain.transform.position, searchRadius, null, SlotStatus, Brain.gameObject, includedTags, excludedTags);

            foreach (var item in results)
            {
                AddTarget(item.smartObject);
            }
        }

        protected override void OnFinish()
        {
            base.OnFinish();

            if (selectedSmartObject != null)
            {
                //Quaternion desiredRotation = Quaternion.Euler(selectedSmartObject.GetAgentSlotPosition(slotIndex).rotation.eulerAngles);
                Brain.transform.rotation = selectedSmartObject.GetAgentSlotPosition(slotIndex).rotation;
            }
        }

        void ReachToDistanceSuccessfully()
        {
            ActionSucceeded();
        }

    }

}
