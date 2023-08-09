using NoOpArmy.WiseFeline.InfluenceMaps;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NoOpArmy.WiseFeline.InfluenceMaps.Sample
{
    /// <summary>
    /// This component uses the influence map to flee from enemies and always tries to put the player in a position with less enemies
    /// </summary>
    public class FleeFromEnemies : MonoBehaviour
    {
        public float speed = 1.5f;
        public InfluenceMapComponent EnemiesMap;

        private InfluenceMap map;
        private Coroutine moveCoroutine;

        public IEnumerator Start()
        {
            map = EnemiesMap.Map;
            while (true)
            {
                var myMapPosition = map.WorldToMapPosition(transform.position);
                //If there is any enemy in 3 meter range then move somewhere else
                //since we just want to know if there is a point with a higher value we will use the returned value and don't need the exact position in the map
                if (map.SearchForValueWithRandomStartingPoint(0.5f, InfluenceMap.SearchCondition.Greater, myMapPosition, 3, out _))
                {
                    if (map.SearchForValueWithRandomStartingPoint(0.5f, InfluenceMap.SearchCondition.Less, myMapPosition, 5, out Vector2Int safeCell))//find safe place in range of 5
                    {
                        Vector3 targetPos = map.MapToWorldPosition(safeCell.x, safeCell.y);
                        Vector3 startPos = transform.position;
                        float w = 0;
                        while (w < 1)
                        {
                            w += Time.deltaTime * speed;
                            transform.position = Vector3.Lerp(startPos, targetPos, w);
                            yield return null;
                        }
                    }
                }

                yield return new WaitForSeconds(0.2f);
            }
        }
    }
}
