using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NoOpArmy.WiseFeline.Sample
{
    public class GoToEnemy : ActionBase
    {
        [Header("Attack")]
        [SerializeField]
        private float _checkForEnemyRadius = 100f;
        [SerializeField]
        private LayerMask _enemyLayerMask;
        [SerializeField]
        private int _searchSize = 50;
        [SerializeField]
        private float _attackRange = 4f;

        private AgentWorker _agentWorker;
        private Collider[] colliders;
        private List<Transform> _transforms;

        protected override void OnInitialized()
        {
            _agentWorker = Brain.GetComponent<AgentWorker>();
            colliders = new Collider[_searchSize];
            _transforms = new List<Transform>();
        }

        protected override void OnUpdate()
        {
            if (ChosenTarget != null)
            {
                if ((_agentWorker.transform.position - (ChosenTarget as Transform).position).sqrMagnitude <= _attackRange * _attackRange)
                {
                    _agentWorker.Movement.StopMove();
                    _agentWorker.Attacker.SetShootTarget(ChosenTarget as Transform);
                }
                else
                {
                    _agentWorker.Movement.MoveTo((ChosenTarget as Transform).position);
                    _agentWorker.Attacker.SetShootTarget(null);
                }
            }
            else
                ActionFailed();
        }

        protected override void UpdateTargets()
        {
            ClearTargets();
            Search.GetSortedTransforms(_agentWorker.transform.position, _checkForEnemyRadius, _enemyLayerMask, ref colliders, ref _transforms, _maxTargetCount);
            foreach (var t in _transforms)
            {
                AddTarget(t);
            }
        }
    }
}
