using NoOpArmy.UtilityAI.Sample;
using NoOpArmy.WiseFeline;
using NoOpArmy.WiseFeline.InfluenceMaps;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace NoOpArmy.UtilityAI.Considerations
{
    /// <summary>
    /// This is a sample consideration to query the influence map for the utility ai system
    /// </summary>
    public class InfluenceMapConsideration : ConsiderationBase
    {
        /// <summary>
        /// The name of the map to consider. This needs a MapManager component to exist in the scene
        [Tooltip("The name of the map to consider. This needs a MapCollection component to exist in the scene")]
        public string mapName;

        private InfluenceMapComponent map;

        /// <summary>
        /// The radius to search
        /// </summary>
        public int radius = 10;

        /// <summary>
        /// The search condition
        /// </summary>
        public InfluenceMap.SearchCondition searchCondition;

        /// <summary>
        /// The value to search for.For example if this is 0.6 and condition is greater, then the search functionality will look for a value bigger than 0.6 in the radius around the target
        /// </summary>
        public float searchValue;

        /// <summary>
        /// the min value we expect to see
        /// </summary>
        public float minValue;

        /// <summary>
        /// The max value we expect to see
        /// </summary>
        public float maxValue;

        /// <summary>
        /// Stores the result of the influence map query to be used by the actions
        /// </summary>
        public Vector2Int queryResult;

        protected override void OnInitialized()
        {
            base.OnInitialized();
            map = FindObjectOfType<MapManager>()?.GetMap(mapName);
        }

        protected override float GetValue(Component target)
        {
            if (map == null || map.Map == null || target == null)
                return 0;
            if (map.Map.SearchForValueWithRandomStartingPoint(searchValue, searchCondition, map.Map.WorldToMapPosition(target.gameObject.transform.position), radius, out Vector2Int result))
            {
                queryResult = result;
                var val = map.Map.GetCellValue(result.x, result.y);
                if (val < minValue) return 0;
                if (val > maxValue) return 1;
                return (val - minValue) / maxValue;
            }
            else
            {
                return 0;
            }
        }
    }
}
