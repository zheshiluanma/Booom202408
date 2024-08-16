using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource BGM;
    void Start()
    {
        AudioClip clip = Resources.Load<AudioClip>("ED");
       BGM.PlayOneShot(clip);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
