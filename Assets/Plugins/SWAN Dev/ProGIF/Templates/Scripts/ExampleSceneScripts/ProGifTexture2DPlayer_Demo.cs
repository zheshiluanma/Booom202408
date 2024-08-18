using System;
using UnityEngine;
using UnityEngine.UI;

public class ProGifTexture2DPlayer_Demo : MonoBehaviour
{
    public ProGifPlayerTexture2D m_ProGifPlayerTexture2D;
    public ProGifPlayerTexture2D image2Pro;
    public RawImage m_RawImage;
    public RawImage image2;
    public Renderer m_Renderer;

    public RawImage m_RawImage2;
    public Renderer m_Renderer2;

    private void Start()
    {
        if(image2Pro==null)
            return;
        image2Pro.Play(Application.dataPath + "/StreamingAssets/电梯.gif", false);
        image2Pro.OnTexture2DCallback = (texture2D) =>
        {
            image2.texture = texture2D;
        };
    }

    public  void OnEnable()
    {
        // if(m_ProGifPlayerTexture2D==null)
        //     return;
        // // Use gif Player Component directly: -----------------------------------------------------
        // m_ProGifPlayerTexture2D.Play(Application.dataPath + "/StreamingAssets/流水线前.gif", false);
        // m_ProGifPlayerTexture2D.OnTexture2DCallback = (texture2D) =>
        // {
        //     // get and display the decoded texture here:
        //     m_RawImage.texture = texture2D;
        //     // set the texture to other texture fields of the shader
        //     //m_Renderer.material.SetTexture("_MetallicGlossMap", texture2D);
        // };


        // // Use the PGif manager: ------------------------------------------------------ 
        // PGif.iPlayGif("https://media.giphy.com/media/p4wvewkDf9OYWjIW2P/giphy.gif", m_RawImage2.gameObject, "MyGifPlayerName 01", (texture2D) => {
        //     // get and display the decoded texture here:
        //     m_RawImage2.texture = texture2D;
        // });
        //
        // PGif.iPlayGif("https://media.giphy.com/media/GOPutjEbvhBHmH455X/giphy.gif", m_Renderer2.gameObject, "MyGifPlayerName 02", (texture2D) => {
        //     // get and display the decoded texture here:
        //     m_Renderer2.material.mainTexture = texture2D;
        // });
    }
}