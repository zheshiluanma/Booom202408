using System;
using Manager;
using UnityEngine;

namespace Interaction
{
    public class ScrectKey : MonoBehaviour
    {
        private InteractionArea _interactionArea;
        private void Start()
        {
            _interactionArea = GetComponent<InteractionArea>();
        }

        public void OnInteract()
        {
            _interactionArea.isInteractable = false;
            DataMgr.Instance.getKey = true;
            gameObject.SetActive(false);
        }
    }
}
