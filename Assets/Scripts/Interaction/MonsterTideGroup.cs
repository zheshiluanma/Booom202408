using System.Collections;
using System.Collections.Generic;
using Interaction;
using Manager;
using Sirenix.OdinInspector;
using UnityEngine;

public class MonsterTideGroup : MonoBehaviour
{
    [ShowInInspector] public MonsterTideCreatePoint ponit1;
    [ShowInInspector] public MonsterTideCreatePoint ponit2;
    public MonsterTideCreatePoint[] monsterTideCreatePoints;

    public IEnumerator StartMonsterTide()
    {
        DataMgr.Instance.remainMonster = 23;
        yield return ponit1.StartMonsterCount();
        yield return ponit2.StartMonsterCount();
        
        for (var i = 0; i < monsterTideCreatePoints.Length; i++)
        {
            StartCoroutine(monsterTideCreatePoints[i].StartMonsterCount())  ;
        }
        yield break;
    }
}