using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class awakeSceneCtrl : MonoBehaviour
{
    public GameObject hide, show;
    public InkDialogueManager inkDialogueManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnClick()
    {
        hide.SetActive(false);
        show.SetActive(true);
        inkDialogueManager.OnDialogueEnd += () =>
        {
            SceneManager.LoadScene("Scene/Start");
        };
        inkDialogueManager.StartStory();
    }
}
