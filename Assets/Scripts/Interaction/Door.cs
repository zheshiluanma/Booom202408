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
        private bool _playDialogue = false;
        private void Start()
        {
            _interactionArea = GetComponent<InteractionArea>();
            _interactionArea.onEnter.AddListener(OnEnter); 
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
                        InkDialogueManager.instance.inkJSONAsset = DataMgr.Instance.interactionJsonAssets[2];
                        InkDialogueManager.instance.StartStory();
                        TaskMgr.Instance.CompleteTask(DataMgr.Instance.nowLevel>=1? "Reboot17":"Reboot14",1);
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

        public void OnEnter()
        {
            if(!_playDialogue)
            {
                InkDialogueManager.instance.inkJSONAsset = DataMgr.Instance.interactionJsonAssets[1];
                InkDialogueManager.instance.StartStory();
                _playDialogue = true;
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