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
    public string id;
    private void Awake()
    {
        //var id=gameObject.name.Replace("Variant","");
        Debug.Log(id);
        var data = DataMgr.Instance.GetEnemyData(id);
        MonsterData = data;
        var health = GetComponent<Health>();
        health.MaximumHealth = data.Hp;
        health.InitialHealth = data.Hp;
        health.InitializeCurrentHealth();
        health.Dfs = data.Dfs;
        //GetComponent<weap>()
    }
}
