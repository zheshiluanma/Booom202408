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
    public bool isBoss;
    private void Awake()
    {
        if (isBoss)
        {
            //var id=gameObject.name.Replace("Variant","");
            Debug.Log(id);
            var health = GetComponent<Health>();
        
            health.MaximumHealth =1000;
            health.InitialHealth = 1000;
            health.InitializeCurrentHealth();
            health.Dfs =30;
            MonsterData = new ActiveData(0, "boss", ActiveType.头目, 1000, 30, 100, 1, 1, 1);

            //GetComponent<weap>()
        }
        else
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
}
