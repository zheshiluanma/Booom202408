using System;
using Manager;
using UnityEngine;

namespace Interaction
{
    public class ScrectKey : MonoBehaviour
    {
        private InteractionArea _interactionArea;
        private bool _playDialogue = false;
        private void Start()
        {
            _interactionArea = GetComponent<InteractionArea>();
            _interactionArea.onEnter.AddListener(OnEnter);
        }

        public void OnInteract()
        {
            _interactionArea.isInteractable = false;
            DataMgr.Instance.getKey = true;
            
            gameObject.SetActive(false);
        }
        
        public void OnEnter()
        {
            if(!_playDialogue)
            {
                InkDialogueManager.instance.inkJSONAsset = DataMgr.Instance.interactionJsonAssets[0];
                InkDialogueManager.instance.StartStory();
                _playDialogue = true;
            }
        }
    }
}
