using NoOpArmy.WiseFeline;
using NoOpArmy.WiseFeline.BlackBoards;
using UnityEngine;
using UnityEngine.AI;

namespace NoOpArmy.UtilityAI.Considerations
{

    /// <summary>
    /// This consideration returns 1 if a valid path from the agent's NavmeshAgent to the position of the GameObject stored in the key is present, otherwise returns 0
    /// The NeedTarget causes the GameObject to be read from the target but always a path from the owning agent is calculated
    /// </summary>
    public class ValidGameObjectPathConsideration : ConsiderationBase
    {
        /// <summary>
        /// The GameObject key to read
        /// </summary>
        [Tooltip("The GameObject key to read")]
        public string vector3KeyName;
        public NavMeshPath navMeshPath;

        private NavMeshAgent agent;

        protected override void OnInitialized()
        {
            agent = Brain.GetComponent<NavMeshAgent>();
            navMeshPath = new NavMeshPath();
        }

        protected override float GetValue(Component target)
        {
            var blackboard = target.GetComponent<BlackBoard>();
            if (blackboard != null)
            {
                if (!blackboard.HasGameObject(vector3KeyName))
                    return 0;

                var value = blackboard.GetGameObject(vector3KeyName);
                agent.CalculatePath(value.transform.position, navMeshPath);
                if (navMeshPath.status == NavMeshPathStatus.PathComplete)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }
    }
}