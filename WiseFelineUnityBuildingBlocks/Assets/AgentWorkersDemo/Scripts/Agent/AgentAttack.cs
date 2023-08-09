using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NoOpArmy.WiseFeline.Sample
{
    public class AgentAttack : MonoBehaviour
    {
        [SerializeField]
        private Projectile _projectilePrefab;
        [SerializeField]
        private Transform _spawnPoint;
        [SerializeField]
        private float _shootRate = 2f;

        private bool _hasTarget;
        private float _timer;
        private Transform _target;

        public void SetShootTarget(Transform shootTarget)
        {
            if (shootTarget != null)
            {
                _target = shootTarget;
                _hasTarget = true;
            }
            else
            {
                _target = null;
                _hasTarget = false;
                _timer = 0;
            }
        }

        private void Update()
        {
            if (_hasTarget)
            {
                _timer += Time.deltaTime;
                if (_timer >= _shootRate)
                {
                    Shoot();
                    _timer = 0;
                }
            }
        }

        private void Shoot()
        {
            if (_target == null)
            {
                _hasTarget = false;
                return;
            }
            Vector3 direction = _target.position - _spawnPoint.position;
            direction.y = 0;
            _projectilePrefab.Instantiate(_spawnPoint.position, direction);
        }
    }
}
