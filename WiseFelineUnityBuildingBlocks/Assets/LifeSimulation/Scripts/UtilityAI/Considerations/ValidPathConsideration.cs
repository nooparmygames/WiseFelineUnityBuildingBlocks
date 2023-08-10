using NoOpArmy.WiseFeline;
using NoOpArmy.WiseFeline.BlackBoards;
using UnityEngine;
using UnityEngine.AI;

namespace NoOpArmy.UtilityAI.Sample
{
    public class ValidPathConsideration : ConsiderationBase
    {
        
        public string keyName;
        private NavMeshAgent agent;
        public NavMeshPath navMeshPath;

        protected override void OnInitialized()
        {
            agent = Brain.GetComponent<NavMeshAgent>();
            navMeshPath = new NavMeshPath();
        }

        protected override float GetValue(Component target)
        {
            BlackBoard blackboard = target.GetComponent<BlackBoard>();
            if(blackboard != null)
            {
                var value = blackboard.GetVector3(keyName);
                agent.CalculatePath(value, navMeshPath);
                if (navMeshPath.status !=NavMeshPathStatus.PathComplete)
                {
                    Debug.Log(navMeshPath.status);
                    return 0;
                }
                else return 1;
            }
            return 0;
        }
    }
}
