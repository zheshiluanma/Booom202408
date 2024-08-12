using System;
using System.Collections;
using System.Collections.Generic;
using Cfg.Data.Active;
using Manager;
using MoreMountains.TopDownEngine;
using UnityEngine;

public class GetMonsterActiveData : MonoBehaviour
{
    public ActiveData MonsterData;
    private void Awake()
    {
        var data = DataMgr.Instance.GetEnemyData(gameObject.name);
        MonsterData = data;
        var health = GetComponent<Health>();
        health.MaximumHealth = data.Hp;
        health.InitialHealth = data.Hp;
        health.InitializeCurrentHealth();
        health.Dfs = data.Dfs;
        //GetComponent<weap>()
    }
}
