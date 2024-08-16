using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomCreate : MonoBehaviour
{
   public void Start()
   {
      var random = Random.Range(0,transform.childCount-1);
      for (var i = 0; i < transform.childCount; i++)
      {
         transform.GetChild(i).gameObject.SetActive(i == random);
      }
   }
}
