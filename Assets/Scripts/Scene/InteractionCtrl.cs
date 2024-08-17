using Manager;
using UnityEngine;

namespace Scene
{
    public class InteractionCtrl : MonoBehaviour
    {
        private void Awake()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(DataMgr.Instance.nowLevel==i); 
            }
        }

        private void Start()
        {
            InkDialogueManager.instance.inkJSONAsset = DataMgr.Instance.inkJSONAssets[DataMgr.Instance.nowLevel];
            InkDialogueManager.instance.StartStory();
        }
    
    
    }
}
