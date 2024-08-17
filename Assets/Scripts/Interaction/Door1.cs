using System;
using System.Collections;
using Manager;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Interaction
{
    public class Door1 : MonoBehaviour
    {
        private InteractionArea _interactionArea;
        private void Start()
        {
            _interactionArea = GetComponent<InteractionArea>();
        }

        public void OnInteract()
        {
            if (DataMgr.Instance.getKey && DataMgr.Instance.remainMonster <= 0&&DataMgr.Instance.charge>=1)
            {
         
                DataMgr.Instance.ShowUpLevelPanel();
            }
        }

    }
}