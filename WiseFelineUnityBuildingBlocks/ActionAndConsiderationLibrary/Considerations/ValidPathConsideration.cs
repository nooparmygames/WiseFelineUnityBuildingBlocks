using NoOpArmy.WiseFeline;
using NoOpArmy.WiseFeline.BlackBoards;
using UnityEngine;
using UnityEngine.AI;

namespace NoOpArmy.UtilityAI.Considerations
{

    /// <summary>
    /// This consideration returns 1 if a valid path from the agent's NavmeshAgent to the position stored in the Vector3 key is present, otherwise returns 0
    /// The NeedTarget causes the Vector3 to be read from the target but always a path from the owning agent is calculated
    /// </summary>
    public class ValidPathConsideration : ConsiderationBase
    {

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
                if (!blackboard.HasVector3(vector3KeyName))
                    return 0;
                var value = blackboard.GetVector3(vector3KeyName);
                agent.CalculatePath(value, navMeshPath);
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