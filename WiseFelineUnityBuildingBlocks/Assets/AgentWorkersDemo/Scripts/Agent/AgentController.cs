using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NoOpArmy.WiseFeline.Sample
{
    public class AgentController : MonoBehaviour
    {
        [SerializeField]
        protected AgentHUD _agentHUD;
        [SerializeField]
        protected Transform _stackPlace;
        [SerializeField]
        protected GameObject _stackPrefab;

        public AgentMovement Movement { get; private set; }
        public AgentAttack Attacker { get; private set; }
        public float Health { get { return _health; }
            set 
            {
                _health = Mathf.Clamp(value, 0, 100);
                _agentHUD.HealthUI.UpdateAmount(_health);
            }
        }
        public bool HaveStack { get { return _haveStack; }
            set 
            {
                _haveStack = value;
                if (value)
                    _woodstack = Instantiate(_stackPrefab, _stackPlace);
                else
                    Destroy(_woodstack);
            } 
        }
        public bool IsUnderAttack { get { return _isUnderAttack; } }

        protected float _health;
        protected bool _haveStack;
        protected GameObject _woodstack;
        protected bool _isUnderAttack;

        protected virtual void Awake()
        {
            Movement = GetComponent<AgentMovement>();
            Attacker = GetComponent<AgentAttack>();
            _health = 100;
        }

        protected virtual void Start()
        {
        }

        public void Damage(float damage)
        {
            Health -= damage;
            _isUnderAttack = true;
            if (Health <= 0)
                Death();
        }

        public virtual void Rest(float energy)
        {
        }

        private void Death()
        {
            _agentHUD.HealthUI.UpdateAmount(0);
            Destroy(gameObject);
        }
    }
}
