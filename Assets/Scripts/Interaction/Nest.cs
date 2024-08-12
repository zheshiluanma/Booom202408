using System;
using System.Collections;
using Manager;
using UnityEngine;

namespace Interaction
{
    public class Nest : MonoBehaviour
    {
        private InteractionArea _interactionArea;
        public GameObject halo;
        public MonsterTideCreatePoint[] monsterTideCreatePoints;
        
        private void Start()
        {
            _interactionArea = GetComponent<InteractionArea>();
        }

        public void OnInteract()
        {
            if(DataMgr.Instance.getKey) return;
            DataMgr.Instance.getKey = true;
            halo.SetActive(true);
            StartCoroutine(Charge());
            foreach (var monsterTideCreatePoint in monsterTideCreatePoints)
            {
                StartCoroutine(monsterTideCreatePoint.StartMonsterCount());
            }
            TaskMgr.Instance.StartMonsterTide(18);
        }

        public IEnumerator Charge()
        {
            DataMgr.Instance.charge = 0f; // 充能开始时，将充能值设置为0

            var duration = 1/30f; // 充能持续时间，单位是秒
            var startTime = Time.time; // 记录充能开始的时间

            while (DataMgr.Instance.charge<1)
            {
                // 计算充能值，范围是0到1
                if(_interactionArea.isInteractable)
                    DataMgr.Instance.charge +=duration;
                Debug.Log("charge: " + DataMgr.Instance.charge);
                yield return new WaitForSeconds(1); // 等待下一帧
            }
            halo.SetActive(false);
            DataMgr.Instance.charge = 1f; // 充能结束时，将充能值设置为1
            yield break;
        }

    }
}