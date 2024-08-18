using System.Collections;
using System.Collections.Generic;
using Interaction;
using Manager;
using UnityEngine;

public class BoomUnder : MonoBehaviour
{
    private InteractionArea _interactionArea;
    private DoorState _state=DoorState.Close;
    private bool _playDialogue = false;
    public GameObject boom;
    private bool ismake;
    private void Start()
    {
    }
    public void OnEnter()
    {
        if(ismake)
            return;
        ismake = true;
        var obj = Instantiate(boom,transform.position,Quaternion.identity);
        obj.SetActive(true);
        Destroy(gameObject);
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(!other.CompareTag("Player"))
        {
            OnEnter();
        }
    }
        
   
        
    public void OnCollisionEnter2D(Collision2D other)
    {
        if(!other.transform.CompareTag("Player"))
        {
            OnEnter();
        }
    }
        
    

}
