using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace NoOpArmy.WiseFeline.Sample
{
    public class StoreStack : ActionBase
    {
        [Header("Store Stack")]
        [SerializeField]
        private float _checkForWarehouseRadius = 100f;
        [SerializeField]
        private LayerMask _warehouseLayerMask;
        [SerializeField]
        private int _searchSize = 50;

        private AgentController _agentController;
        private Collider[] colliders;
        private List<Transform> _transforms;

        protected override void OnInitialized()
        {
            _agentController = Brain.GetComponent<AgentController>();
            colliders = new Collider[_searchSize];
            _transforms = new List<Transform>();
        }

        protected override void OnStart()
        {
            if (ChosenTarget != null)
            {
                Vector3 destination = ChosenTarget.transform.position;
                _agentController.Movement.MoveTo(destination, null);
            }
        }

        protected override void UpdateTargets()
        {
            ClearTargets();
            Search.GetSortedTransforms(_agentController.transform.position, _checkForWarehouseRadius, _warehouseLayerMask, ref colliders, ref _transforms, _maxTargetCount);
            foreach (var t in _transforms)
            {
                AddTarget(t);
            }
        }
    }
}
