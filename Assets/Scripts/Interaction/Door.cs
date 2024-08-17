using System;
using System.Collections;
using Manager;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Interaction
{
    public class Door : MonoBehaviour
    {
        private InteractionArea _interactionArea;
        private DoorState _state=DoorState.Close;
        public MonsterTideCreatePoint monsterTideCreatePoint;
        private void Start()
        {
            _interactionArea = GetComponent<InteractionArea>();
        }

        public void OnInteract()
        {
            switch (_state)
            {
                case DoorState.Close:
                    if (DataMgr.Instance.getKey)
                    {
                        _interactionArea.isInteractable = false;
                        DataMgr.Instance.getKey = false;
                        TaskMgr.Instance.StartMonsterTide(13);
                        _state = DoorState.Charge;
                        StartCoroutine(monsterTideCreatePoint.StartMonsterCount());
                        StartCoroutine(OpenDoor());
                    }
                    break;
                case DoorState.Charge:
                    break;
                case DoorState.Open:
                    DataMgr.Instance.ShowUpLevelPanel();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            
        }

        private IEnumerator OpenDoor()
        {
            while (DataMgr.Instance.remainMonster>0)
            {
                yield return new WaitForSeconds(1);
            }
            _state = DoorState.Open;
        }
    }
    public enum DoorState
    {
        Close,
        Charge,
        Open
    }
}