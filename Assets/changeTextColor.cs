using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class changeTextColor : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
   

    public void OnPointerEnter(PointerEventData eventData)
    {
        GetComponent<TMP_Text>().color=Color.yellow;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GetComponent<TMP_Text>().color=Color.white;
    }
}