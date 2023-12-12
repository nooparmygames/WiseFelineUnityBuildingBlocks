using NoOpArmy.WiseFeline;
using NoOpArmy.WiseFeline.BlackBoards;
using UnityEngine;

namespace NoOpArmy.UtilityAI.Actions
{
    /// <summary>
    /// Actions which want to do some blackboard changes along side their custom code can derive from this
    /// </summary>
    public class BlackboardActionBase : ActionBase
    {

        /// <summary>
        /// The start delay before changes start taking effect.
        /// </summary>
        [Tooltip("The start delay before changes in seconds")]
        public float changerStartingDelayInSeconds;

        /// <summary>
        /// If true, upon completion of this action, it will prompt the brain to immediately update the target for all actions.
        /// </summary>
        [Tooltip("If true, upon completion of this action, it will prompt the brain to immediately update the target for all actions.")]
        public bool forceUpdateTargetsOnFinish = false;

        /// <summary>
        /// Resets the changer whenever this action is selected. Mostly useful for changers which execute a specific number of times
        /// </summary>
        [Tooltip("Resets the changer whenever this action is selected. Mostly useful for changers which execute a specific number of times")]
        public bool ResetChangerOnStart = false;

        /// <summary>
        /// The change you want to happen to the blackboard during this action
        /// </summary>
        [Tooltip("The change you want to happen to the blackboard during this action")]
        public BlackBoardChangeer changer;

        [Tooltip("During initialization, we attempt to find the animation controller in the game object hierarchy and set this trigger at the start of the action.")]
        public string OnStartAnimationTrigger;
        int triggerHash;

        /// <summary>
        /// The blackboard to use for changes
        /// </summary>
        protected BlackBoard blackBoard;

        private float currentStartDelay = 0;
        Animator animator;

        protected override void OnInitialized()
        {
            base.OnInitialized();

            animator = Brain.GetComponentInChildren<Animator>();
            triggerHash = Animator.StringToHash(OnStartAnimationTrigger);
        }

        protected override void OnStart()
        {
            base.OnStart();
            blackBoard = Brain.GetComponent<BlackBoard>();
            currentStartDelay = 0;

            if (ResetChangerOnStart)
                changer.Reset();


            if (animator != null && !string.IsNullOrEmpty(OnStartAnimationTrigger))
            {
                animator.SetTrigger(triggerHash);
            }

        }

        protected override void OnUpdate()
        {
            base.OnUpdate();

            if (currentStartDelay < changerStartingDelayInSeconds)
                currentStartDelay += Time.deltaTime;
            else
                changer.Update(blackBoard);
        }

        protected override void UpdateTargets()
        {

        }

        protected override void OnFinish()
        {
            base.OnFinish();
            if (forceUpdateTargetsOnFinish)
                Brain.UpdateActionsTargets();
        }
    }
}