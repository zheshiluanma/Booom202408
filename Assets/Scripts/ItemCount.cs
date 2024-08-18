using System.Collections;
using System.Collections.Generic;
using Manager;
using TMPro;
using UnityEngine;

public class ItemCount : MonoBehaviour
{
    // Start is called before the first frame update
    TMP_Text _text;
    public ItemType itemType;
    void Start()
    {
        _text = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        _text.text = "x" + DataMgr.Instance.backpackItems[(int)itemType].count;
    }
}
