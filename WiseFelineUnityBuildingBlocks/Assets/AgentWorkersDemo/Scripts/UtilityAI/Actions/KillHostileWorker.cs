using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NoOpArmy.WiseFeline.Sample
{
    public class KillHostileWorker : ActionBase
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

        private AgentEnemy _enemyAgent;
        private Collider[] colliders;
        private List<Transform> _transforms;

        protected override void OnInitialized()
        {
            _enemyAgent = Brain.GetComponent<AgentEnemy>();
            colliders = new Collider[_searchSize];
            _transforms = new List<Transform>();
        }

        protected override void OnUpdate()
        {
            if (ChosenTarget != null)
            {
                if ((_enemyAgent.transform.position - (ChosenTarget as Transform).position).sqrMagnitude <= _attackRange * _attackRange)
                {
                    _enemyAgent.Movement.StopMove();
                    _enemyAgent.Attacker.SetShootTarget(ChosenTarget as Transform);
                }
                else
                {
                    _enemyAgent.Movement.MoveTo((ChosenTarget as Transform).position);
                    _enemyAgent.Attacker.SetShootTarget(null);
                }
            }
            else
                ActionFailed();
        }

        protected override void UpdateTargets()
        {
            ClearTargets();
            Search.GetSortedTransforms(_enemyAgent.transform.position, _checkForEnemyRadius, _enemyLayerMask, ref colliders, ref _transforms, _maxTargetCount);
            foreach (var t in _transforms)
            {
                AddTarget(t);
            }
        }
    }
}
