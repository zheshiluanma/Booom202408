using Interaction;
using Manager;
using UnityEngine;

public class Lab : MonoBehaviour
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
        // _interactionArea.isInteractable = false;
        // DataMgr.Instance.getKey = true;
        // TaskMgr.Instance.CompleteTask(DataMgr.Instance.nowLevel>=1? "GetKey17":"GetKey14",1);
        // gameObject.SetActive(false);
    }
        
    public void OnEnter()
    {
        if(!_playDialogue)
        {
            InkDialogueManager.instance.inkJSONAsset = DataMgr.Instance.interactionJsonAssets[4];
            InkDialogueManager.instance.StartStory();
            _playDialogue = true;
            DataMgr.Instance.getKey = true;
        }
    }
    
    
    
}
