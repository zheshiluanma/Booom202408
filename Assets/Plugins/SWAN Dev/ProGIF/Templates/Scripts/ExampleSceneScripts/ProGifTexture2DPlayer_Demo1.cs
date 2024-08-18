using System;
using UnityEngine;
using UnityEngine.UI;

public class ProGifTexture2DPlayer_Demo2 : MonoBehaviour
{
    public ProGifPlayerTexture2D image2Pro;
    public RawImage image2;
    

    private void Start()
    {
        if(image2Pro==null)
            return;
        image2Pro.Play(Application.dataPath + "/StreamingAssets/闪光.gif", false);
        image2Pro.OnTexture2DCallback = (texture2D) =>
        {
            image2.texture = texture2D;
        };
    }
}