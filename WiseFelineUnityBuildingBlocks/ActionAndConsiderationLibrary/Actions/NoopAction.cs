using NoOpArmy.WiseFeline;
using UnityEngine;

namespace NoOpArmy.UtilityAI.Actions
{
    /// <summary>
    /// This action is our favorite and doesn't do anything.
    /// It optionally can stop movement too.
    /// </summary>
    public class NoopAction : BlackboardActionBase
    {
        /// <summary>
        /// Halt agent movement when utilizing IAIMovement.
        /// </summary>
        [Tooltip("Halt agent movement when utilizing IAIMovement.")]
        [SerializeField] bool StopMoving;

        protected override void OnStart()
        {
            base.OnStart();

            if(StopMoving)
            {
                var movement = Brain.GetComponent<IAIMovement>();
                if (movement != null)
                    movement.StopMoving();
            }
        }

        protected override void UpdateTargets()
        {

        }
    }
}