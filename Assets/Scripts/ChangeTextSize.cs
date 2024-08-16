using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChangeTextSize : MonoBehaviour
{
    private RectTransform _text;
    private RectTransform _thisRect;
    private void Start()
    {
        _text = transform.parent.GetComponent<RectTransform>();
        _thisRect = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        _text.sizeDelta = new Vector2(_text.sizeDelta.x, _thisRect.sizeDelta.y+15);
    }
}
