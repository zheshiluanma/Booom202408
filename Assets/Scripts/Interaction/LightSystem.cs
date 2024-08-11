using Manager;
using UnityEngine;

namespace Interaction
{
    public class LightSystem : MonoBehaviour
    {
        private InteractionArea _interactionArea;
        public MonsterTideGroup monsterTideGroup;
        private bool _isactive = false;
        private void Start()
        {
            _interactionArea = GetComponent<InteractionArea>();
        }

        public void OnInteract()
        {
            _interactionArea.isInteractable = false;
            DataMgr.Instance.fixLight++;
            if (DataMgr.Instance.fixLight >= 4)
            {
                StartCoroutine(monsterTideGroup.StartMonsterTide());
            }
        }
    }
}