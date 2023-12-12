using NoOpArmy.WiseFeline;
using NoOpArmy.WiseFeline.BlackBoards;
using NoOpArmy.WiseFeline.InfluenceMaps;
using UnityEngine;

namespace NoOpArmy.UtilityAI.Considerations
{
    /// <summary>
    /// This consideration searches the influence map specified for a value and returns 1 if it finds something. Otherwise it returns 0
    /// </summary>
    public class InfluenceMapConsideration : ConsiderationBase
    {

        private BlackBoard blackBoard;
        private InfluenceMapComponentBase map;

        /// <summary>
        /// The name of the map to consider.
        [Tooltip("The name of the map to consider.")]
        public string mapName;

        /// <summary>
        /// The radius to search in map cells
        /// </summary>
        [Tooltip("The radius to search in map cells")]
        public int radius = 10;

        /// <summary>
        /// The search condition
        /// </summary>
        public SearchCondition searchCondition;

        /// <summary>
        /// The value to search for.For example if this is 0.6 and condition is greater, then the search functionality will look for a value bigger than 0.6 in the radius around the target
        /// </summary>
        public float searchValue;

        /// <summary>
        /// Stores the result of the influence map query to be used by the actions in a Vector3 blackboard key. The results will be in x and z components in influence map cells coordinates. Leave this empty if you don't need it.
        /// </summary>
        [Tooltip("Stores the result of the influence map query to be used by the actions in a Vector3 blackboard key. The results will be in x and z components in influence map cells coordinates. Leave this empty if you don't need it.")]
        public string queryResultKeyName;

        protected override void OnInitialized()
        {
            base.OnInitialized();
            map = InfluenceMapCollection.Instance.GetMap(mapName);
            blackBoard = Brain.GetComponent<BlackBoard>();
        }

        protected override float GetValue(Component target)
        {
            if (!map.IsMapValid() || target == null)
                return 0;
            if (map.SearchForValueWithRandomStartingPoint(searchValue, searchCondition, map.WorldToMapPosition(target.transform.position), radius, out Vector2Int result))
            {
                if (!string.IsNullOrEmpty(queryResultKeyName))
                    blackBoard.SetVector3(queryResultKeyName, map.MapToWorldPosition(result.x, result.y));
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}