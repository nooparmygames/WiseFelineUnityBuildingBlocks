using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NoOpArmy.WiseFeline.Sample
{
    public class ConsiderVillageUnderAttack : ConsiderationBase
    {
        protected override float GetValue(Component target)
        {
            return GameManager.Instance.IsVillageUnderAttack ? 1f : 0f;
        }
    }
}
