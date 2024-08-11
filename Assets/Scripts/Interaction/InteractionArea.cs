using System;
using Manager;
using UnityEngine;
using UnityEngine.Events;

namespace Interaction
{
    public class InteractionArea : MonoBehaviour
    {
        public UnityEvent onInteract;
        public bool isInteractable;
        public void OnTriggerEnter2D(Collider2D other)
        {
            if(other.CompareTag("Player"))
            {
                Debug.Log("Player entered the interaction area");
                isInteractable = true;
                TipsMgr.Instance.ShowTips("Press E to interact");
            }
        }
        
        public void OnTriggerExit2D(Collider2D other)
        {
            if(other.CompareTag("Player"))
            {
                Debug.Log("Player exited the interaction area");
                isInteractable = false;
                TipsMgr.Instance.HideTips();
            }
        }
        
        public void OnCollisionEnter2D(Collision2D other)
        {
            if(other.transform.CompareTag("Player"))
            {
                Debug.Log("Player entered the interaction area");
                isInteractable = true;
                TipsMgr.Instance.ShowTips("Press E to interact");
            }
        }
        
        public void OnCollisionExit2D(Collision2D other)
        {
            if(other.transform.CompareTag("Player"))
            {
                Debug.Log("Player exited the interaction area");
                isInteractable = false;
                TipsMgr.Instance.HideTips();
            }
        }

        private void Update()
        {
            if (isInteractable&&Input.GetKeyDown(KeyCode.E))
            {
                onInteract.Invoke();
            }
        }
    }
}
