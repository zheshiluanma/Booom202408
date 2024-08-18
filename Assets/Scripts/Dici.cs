using System.Collections;
using System.Collections.Generic;
using Manager;
using MoreMountains.TopDownEngine;
using UnityEngine;

public class Dici : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(!other.CompareTag("Player"))
        {
            if(other.TryGetComponent<Health>(out var enemy))
                enemy.Damage(DataMgr.Instance.GetBoomDamage()*0.5f,DataMgr.Instance.player,0,0,transform.position);
        }
    }
    public void OnCollisionEnter2D(Collision2D other)
    {
        if(!other.transform.CompareTag("Player"))
        {
            if(other.transform.TryGetComponent<Health>(out var enemy))
                enemy.Damage(DataMgr.Instance.GetBoomDamage()*0.5f,DataMgr.Instance.player,0,0,transform.position);
            if (other.transform.TryGetComponent<AIActionMoveTowardsTarget2D>(out var move))
            {
                move.speed*=0.5f;   
            }
        }
    }
}
