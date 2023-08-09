using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NoOpArmy.WiseFeline.Sample
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField]
        private float _speed = 5f;
        [HideInInspector]
        public Vector3 Direction;
        [SerializeField]
        private LayerMask _effectiveOnLayer;
        
        private Rigidbody _rb;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
        }

        void Shoot()
        {
            _rb.velocity = Direction.normalized * _speed;
        }

        public void Instantiate(Vector3 position, Vector3 direction)
        {
            Projectile projectile = Instantiate(this, position, Quaternion.identity);
            projectile.Direction = direction;
            projectile.Shoot();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out AgentController agent))
            {
                if (_effectiveOnLayer == (_effectiveOnLayer | (1 << agent.gameObject.layer)))
                {
                    agent.Damage(10);
                    Destroy(gameObject);
                }
            }
        }
    }
}
