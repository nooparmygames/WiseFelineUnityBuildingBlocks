using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NoOpArmy.WiseFeline.Sample
{
    public class Resource : MonoBehaviour
    {
        [SerializeField]
        private float _choppingDuration = 4f;
        [SerializeField]
        private float _effectSpeed = 1f;

        public bool IsTarget { get; set; }

        private float _timer = 0;
        private Action _callback;

        public void ChopTree(Action callback)
        {
            _callback = callback;
            StartCoroutine(ChopEffect());
        }

        private IEnumerator ChopEffect()
        {
            while (_timer < _choppingDuration)
            {
                _timer += Time.deltaTime;
                transform.localRotation = Quaternion.Euler(Mathf.Sin(Time.time * _effectSpeed) * 20f, 0f, 0f);
                yield return null;
            }
            _callback?.Invoke();
            Destroy(gameObject);
        }
    }
}
