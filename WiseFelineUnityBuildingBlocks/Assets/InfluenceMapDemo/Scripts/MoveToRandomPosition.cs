using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NoOpArmy.WiseFeline.InfluenceMaps.Sample
{
    /// <summary>
    /// This component just moves an object to a random position so it can be used as a test enemy
    /// </summary>
    public class MoveToRandomPosition : MonoBehaviour
    {
        public Rect area = new Rect(0, 0, 20, 20);


        IEnumerator Start()
        {
            yield return new WaitForSeconds(Random.Range(0, 1.3f));
            float w = 0;
            while (true)
            {
                var startPosition = transform.position;
                var targetPosition = new Vector3(Random.Range(area.x, area.width), 0, Random.Range(area.y, area.height));
                while (w < 1)
                {
                    w += Time.deltaTime;
                    transform.position = Vector3.Lerp(startPosition, targetPosition, w);
                    yield return null;
                }

                w = 0;
                yield return new WaitForSeconds(1);
            }
        }

    }
}
