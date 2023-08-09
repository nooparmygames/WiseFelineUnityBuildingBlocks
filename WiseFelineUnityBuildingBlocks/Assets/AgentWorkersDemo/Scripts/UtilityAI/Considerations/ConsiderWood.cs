using UnityEngine;

namespace NoOpArmy.WiseFeline.Sample
{
    public class ConsiderWood : ConsiderationBase
    {
        protected override float GetValue(Component target)
        {
            return GameManager.Instance.Wood;
        }
    }
}
