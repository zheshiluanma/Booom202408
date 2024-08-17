using System;
using System.Collections;
using Manager;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Interaction
{
    public class Door3 : MonoBehaviour
    {
        private InteractionArea _interactionArea;
        private bool isShow;
        private void Start()
        {
            _interactionArea = GetComponent<InteractionArea>();
            _interactionArea.onEnter.AddListener(OnEnter);
        }

        private void OnEnter()
        {
            if(isShow)
                return;
            isShow = true;
            InkDialogueManager.instance.inkJSONAsset = DataMgr.Instance.interactionJsonAssets[5];
            InkDialogueManager.instance.StartStory();
        }

        public void OnInteract()
        {
            if (DataMgr.Instance.getKey)
            {
                DataMgr.Instance.ShowUpLevelPanel();
            }
        }

    }
}