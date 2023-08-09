using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace NoOpArmy.WiseFeline.Sample
{
    public class GoToTree : ActionBase
    {
        [Header("Go To Tree")]
        [SerializeField]
        private float _checkForTreeRadius = 100f;
        [SerializeField]
        private LayerMask _treeLayerMask;
        [SerializeField]
        private int _searchSize = 50;
        [SerializeField]
        private float _chopEnergyCost = 10f;
        
        private AgentWorker _agentWorker;
        private Collider[] colliders;
        private List<Transform> _transforms;
        private Resource currentTree;

        protected override void OnInitialized()
        {
            _agentWorker = Brain.GetComponent<AgentWorker>();
            colliders = new Collider[_searchSize];
            _transforms = new List<Transform>();
        }

        protected override void OnStart()
        {
            if (ChosenTarget != null)
            {
                if (ChosenTarget.TryGetComponent(out Resource resource))
                {
                    if (resource.IsTarget)
                    {
                        ActionFailed();
                        return;
                    }
                    else
                    {
                        resource.IsTarget = true;
                        currentTree = resource;
                    }
                }

                Vector3 destination = ChosenTarget.transform.position;
                _agentWorker.Movement.MoveTo(destination, ChopTree);
            }
            else
                ActionFailed();
        }

        private void ChopTree()
        {
            if (currentTree != null)
            {
                currentTree.ChopTree(GatherWood);
                _agentWorker.Energy -= _chopEnergyCost;
                return;
            }

            ActionFailed();
        }

        private void GatherWood()
        {
            _agentWorker.HaveStack = true;
        }

        protected override void OnFinish()
        {
            if (currentTree != null)
            {
                currentTree.IsTarget = false;
                currentTree = null;
            }
        }

        protected override void UpdateTargets()
        {
            ClearTargets();
            Search.GetSortedTransforms(_agentWorker.transform.position, _checkForTreeRadius, _treeLayerMask, ref colliders, ref _transforms, _maxTargetCount);
            foreach (var t in _transforms)
            {
                if (t.TryGetComponent(out Resource resource))
                {
                    if (!resource.IsTarget || resource == currentTree)
                        AddTarget(t);
                }
            }
        }
    }
}
