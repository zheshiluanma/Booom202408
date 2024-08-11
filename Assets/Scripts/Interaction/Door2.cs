using System;
using System.Collections;
using Manager;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Interaction
{
    public class Door2 : MonoBehaviour
    {
        private InteractionArea _interactionArea;
        private void Start()
        {
            _interactionArea = GetComponent<InteractionArea>();
        }

        public void OnInteract()
        {
            if (DataMgr.Instance.remainMonster <= 0&&DataMgr.Instance.fixLight>=4)
            {
                SceneManager.LoadScene("Level1");
                DataMgr.Instance.getKey = false;
                DataMgr.Instance.charge = 0;
                DataMgr.Instance.fixLight = 0;
            }
        }

    }
}