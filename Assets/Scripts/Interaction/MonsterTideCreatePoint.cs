using System.Collections;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Interaction
{
    public class MonsterTideCreatePoint : MonoBehaviour
    {
        public int[] monsterCount;
        public int waitTime;

        public IEnumerator StartMonsterCount()
        {
            for (var i = 0; i < monsterCount.Length; i++)
            {
                for (var j = 0; j < monsterCount[i]; j++)
                {
                    Addressables.InstantiateAsync("genzong2_MT").Completed += handle =>
                    {
                        handle.Result.transform.position = transform.position;
                    };
                }
                yield return new WaitForSeconds(waitTime);
            }
        }
        
    }
}