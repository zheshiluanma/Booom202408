using System.Collections;
using System.Collections.Generic;
using Interaction;
using Manager;
using UnityEngine;

public class ItemGrab : MonoBehaviour
{
    public ItemType itemType;
    private InteractionArea _interactionArea;
    private void Start()
    {
        _interactionArea = GetComponent<InteractionArea>();
        _interactionArea.onInteract.AddListener(OnEnter); 
    }
    
    public void OnEnter()
    {
        DataMgr.Instance.backpackItems[(int)itemType].OnPickUp();
        Destroy(gameObject);
    }
}
