using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NoOpArmy.WiseFeline.Sample
{
    public class CameraManager : MonoBehaviour
    {
        private List<Camera> _allCameras;
        private List<Camera> _activeCameras;
        private int index = -1;

        void Start()
        {
            _allCameras = new List<Camera>(GetComponentsInChildren<Camera>(true));
            _allCameras.Insert(0, Camera.main);
            NextCamera();
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                NextCamera();
            }
        }

        private void NextCamera()
        {
            _allCameras.RemoveAll(c => c == null);
            _activeCameras = _allCameras.FindAll(c => c.gameObject.activeInHierarchy);
            index = (index + 1) % _activeCameras.Count;
            for (int i = 0; i < _activeCameras.Count; i++)
            {
                if (i == index)
                    _activeCameras[i].enabled = true;
                else
                    _activeCameras[i].enabled = false;
            }
        }
    }
}
