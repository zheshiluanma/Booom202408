using System;
using System.Collections;
using System.Collections.Generic;
using Manager;
using UnityEngine;

public class BackpackItem : MonoBehaviour
{
    public int count;
    public string itemName;
    public Sprite itemSprite;
    public Sprite cannotuse;
    public bool canuse;
    public SpriteRenderer spriteRenderer;
    private int _OBcount;
    private Camera _mainCamera;
    public ItemType itemType;
    public GameObject item;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        _mainCamera = Camera.main;
    }

    public void OnSelect()
    {
        gameObject.SetActive(true);
    }
    
    public void OnUse()
    {
        count--;
        switch (itemType)
        {
            case ItemType.手榴弹:
                break;
            case ItemType.地雷:
                break;
            case ItemType.地刺:
                break;
        }
        var obj = Instantiate(item,transform.position,Quaternion.identity);
        obj.SetActive(true);
    }

    private void OnDisable()
    {
        _OBcount = 0;
    }

    private void Update()
    {
        canuse = _OBcount <= 0 && count > 0;
        spriteRenderer.sprite =canuse ? itemSprite : cannotuse;
        DataMgr.Instance.noisePos =DataMgr.Instance.player.transform.position;
        if(Input.GetMouseButtonDown(0)&&canuse)
            OnUse();
        var mousePosition =_mainCamera.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mousePosition.x,mousePosition.y,0);
    }
    
    public void OnPickUp()
    {
        count++;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log(other.gameObject.name);
        if(other.transform.CompareTag("Obstacles"))
            _OBcount++;
    }

    private void OnCollisionExit2D(Collision2D other)
    {
         if(other.transform.CompareTag("Obstacles"))
            _OBcount--;
    }
}

public enum ItemType
{
    手榴弹,
    地雷,
    地刺
}