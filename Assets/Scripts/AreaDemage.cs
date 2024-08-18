using System;
using System.Collections;
using System.Collections.Generic;
using Manager;
using MoreMountains.TopDownEngine;
using Sirenix.Utilities;
using UnityEngine;

public class AreaDemage : MonoBehaviour
{
    private void Start()
    {
        foreach (var collider1 in Physics2D.OverlapCircleAll(new Vector2(transform.position.x,transform.position.y),1.2f))
        {
            Debug.Log(collider1.name);
            if(collider1.TryGetComponent<Health>(out var enemy))
                enemy.Damage(DataMgr.Instance.GetBoomDamage(),DataMgr.Instance.player,0,0,transform.position);
        }
    }
}
